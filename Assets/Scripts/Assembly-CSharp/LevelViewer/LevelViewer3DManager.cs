using System.Collections.Generic;
using System.Linq;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LevelViewer
{
    public class LevelViewer3DManager : MonoBehaviour
    {
        // --- Data ---
        private LevelCohortSO[] _cohorts;
        private string[] _cohortNames;
        private int _selectedCohortIndex;
        private int _selectedLevelIndex;
        private ParsedLevel _currentParsed;
        private LevelDataSO _currentLevelData;

        // --- 3D Objects ---
        private Transform _levelRoot;
        private readonly Dictionary<string, GameObject> _prefabCache = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, GameObject> _editorPrefabCache = new Dictionary<string, GameObject>();
        private readonly Dictionary<PillKind, Mesh> _fruitMeshCache = new Dictionary<PillKind, Mesh>();
        private readonly Dictionary<PillKind, Material> _fruitMatCache = new Dictionary<PillKind, Material>();
        private Camera _mainCamera;
        private Material _grassGroundMat;
        private Material _fallbackMatTemplate;
        private LevelViewerTileDefinitionLookup _tileLookup;

        // --- Material Fix System ---
        private Shader _unlitShader;
        private readonly Dictionary<Material, Material> _fixedMatCache = new Dictionary<Material, Material>();
        private readonly List<Material> _runtimeMats = new List<Material>();

        // --- UI State ---
        private Vector2 _levelListScroll;
        private Vector2 _infoScroll;
        private bool _showMapLayer = true;
        private bool _showLdfLayer = false;
        private bool _showSpawnLayer = true;
        private bool _showFirstSpawnWaveOnly = true;
        private string _searchFilter = "";
        private bool _initialized;

        // --- Camera Control ---
        private float _cameraZoom = 15f;
        private bool _isDragging;
        private Vector3 _lastMousePosition;

        // --- Styles ---
        private GUIStyle _headerStyle;
        private GUIStyle _subHeaderStyle;
        private GUIStyle _levelBtnStyle;
        private GUIStyle _levelBtnSelectedStyle;
        private GUIStyle _boxStyle;
        private GUIStyle _legendStyle;
        private GUIStyle _smallLabelStyle;
        private bool _stylesBuilt;

        // --- Colors ---
        private static readonly Color GRASS_COLOR = new Color(0.38f, 0.72f, 0.28f, 1f); // Bright green grass
        private static readonly Color BG_COLOR = new Color(0.32f, 0.62f, 0.24f, 1f);    // Slightly darker green bg

        private void Start()
        {
            _mainCamera = Camera.main;
            if (_mainCamera == null) _mainCamera = FindFirstObjectByType<Camera>();

            // Use the same front-facing perspective setup as the gameplay sandbox so mesh depth reads correctly.
            if (_mainCamera != null)
            {
                if (_mainCamera.GetComponent<UniversalAdditionalCameraData>() == null)
                    _mainCamera.gameObject.AddComponent<UniversalAdditionalCameraData>();

                _mainCamera.orthographic = false;
                _mainCamera.transform.rotation = Quaternion.identity;
                _mainCamera.fieldOfView = 32f;
                _mainCamera.backgroundColor = BG_COLOR;
                _mainCamera.clearFlags = CameraClearFlags.SolidColor;
                _mainCamera.nearClipPlane = 0.1f;
                _mainCamera.farClipPlane = 200;
            }

            // Prepare shared materials
            PrepareMaterials();
            _tileLookup = LevelViewerTileDefinitionLookup.Load();

            LoadCohorts();
            _initialized = true;
            if (_cohorts != null && _cohorts.Length > 0)
            {
                SelectCohort(0);
            }
        }

        private void PrepareMaterials()
        {
            // Find the best available unlit shader for this URP project
            _unlitShader = Shader.Find("Universal Render Pipeline/Unlit");
            if (_unlitShader == null) _unlitShader = Shader.Find("Unlit/Color");
            if (_unlitShader == null) _unlitShader = Shader.Find("Standard");

            if (_unlitShader == null)
            {
                Debug.LogError("[LevelViewer3D] Could not find any usable shader!");
                return;
            }

            _grassGroundMat = new Material(_unlitShader);
            _grassGroundMat.name = "GrassMat_Runtime";
            SetMatColor(_grassGroundMat, GRASS_COLOR);
            SetGrassTexture(_grassGroundMat);
            SetCullOff(_grassGroundMat);

            _fallbackMatTemplate = new Material(_unlitShader);
            _fallbackMatTemplate.name = "FallbackMat_Runtime";
            SetCullOff(_fallbackMatTemplate);
        }

        /// <summary>
        /// After a prefab is instantiated, keep the authored material/shader setup.
        /// The reference Sandbox scene relies on these shader properties for tile gradients.
        /// </summary>
        private void FixPrefabMaterials(GameObject instance)
        {
            foreach (var renderer in instance.GetComponentsInChildren<Renderer>(true))
            {
                if (renderer == null) continue;
                renderer.enabled = true;
            }
        }

        /// <summary>
        /// Try to extract the most representative color from a material,
        /// checking common property names in order of priority.
        /// </summary>
        private static Color ExtractColorFromMaterial(Material mat)
        {
            // Priority list of color properties to try
            string[] colorProps = {
                "_Main_Color_1",   // SH_Tile_FakeUnlit - top face color
                "_BaseColor",      // URP Lit standard
                "_Color",          // Most shaders
                "_MainColor",
                "_TintColor",
            };

            foreach (var prop in colorProps)
            {
                if (mat.HasProperty(prop))
                {
                    var c = mat.GetColor(prop);
                    // Skip if nearly transparent or completely black (likely unset)
                    if (c.a > 0.01f && (c.r + c.g + c.b) > 0.05f)
                        return new Color(c.r, c.g, c.b, 1f);
                }
            }

            // Final fallback: white
            return Color.white;
        }

        /// <summary>Set color on both _BaseColor and _Color so it works on any URP shader.</summary>
        private static void SetMatColor(Material mat, Color color)
        {
            if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", color);
            if (mat.HasProperty("_Color"))     mat.SetColor("_Color",     color);
        }

        private static void SetMatTexture(Material mat, Texture texture)
        {
            if (texture == null) return;
            if (mat.HasProperty("_BaseMap")) mat.SetTexture("_BaseMap", texture);
            if (mat.HasProperty("_MainTex")) mat.SetTexture("_MainTex", texture);
        }

        private static void SetMatTextureScale(Material mat, Vector2 scale)
        {
            if (mat.HasProperty("_BaseMap")) mat.SetTextureScale("_BaseMap", scale);
            if (mat.HasProperty("_MainTex")) mat.SetTextureScale("_MainTex", scale);
        }

        private static void SetGrassTexture(Material mat)
        {
#if UNITY_EDITOR
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Texture2D/Platform_Grass.png");
            if (texture == null) return;

            texture.wrapMode = TextureWrapMode.Repeat;
            SetMatTexture(mat, texture);
#endif
        }

        private static void SetCullOff(Material mat)
        {
            if (mat == null) return;
            if (mat.HasProperty("_Cull")) mat.SetFloat("_Cull", 0f);
        }

        private void Update()
        {
            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            if (_mainCamera == null) return;

            float mouseX = Input.mousePosition.x;
            float sw = Screen.width;
            bool overUI = mouseX < 250 || mouseX > sw - 270;

            if (!overUI)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                if (Mathf.Abs(scroll) > 0.001f)
                {
                    _cameraZoom = Mathf.Clamp(_cameraZoom - scroll * _cameraZoom * 0.5f, 2f, 60f);
                    if (_mainCamera.orthographic)
                    {
                        _mainCamera.orthographicSize = _cameraZoom;
                    }
                    else
                    {
                        var pos = _mainCamera.transform.position;
                        pos.z = -_cameraZoom;
                        _mainCamera.transform.position = pos;
                    }
                }

                if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                {
                    _isDragging = true;
                    _lastMousePosition = Input.mousePosition;
                }
            }

            if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
                _isDragging = false;

            if (_isDragging)
            {
                Vector3 delta = Input.mousePosition - _lastMousePosition;
                float panSpeed = _cameraZoom * 2f / Screen.height;
                _mainCamera.transform.position -= new Vector3(delta.x * panSpeed, delta.y * panSpeed, 0);
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetKeyDown(KeyCode.F) && _currentParsed != null)
                CenterCamera();
        }

        private void CenterCamera()
        {
            if (_mainCamera == null || _currentParsed == null) return;
            float centerX = (_currentParsed.Width - 1) * 0.5f;
            float centerY = -(_currentParsed.Height - 1) * 0.5f;
            _cameraZoom = Mathf.Clamp(Mathf.Max(_currentParsed.Width, _currentParsed.Height) * 1.55f, 10f, 60f);
            _mainCamera.transform.rotation = Quaternion.identity;
            _mainCamera.transform.position = new Vector3(centerX, centerY, -_cameraZoom);

            if (_mainCamera.orthographic)
                _mainCamera.orthographicSize = Mathf.Max(_currentParsed.Width, _currentParsed.Height) * 0.6f;
            else
                _mainCamera.fieldOfView = 32f;
        }

        // --- Data Loading ---

        private void LoadCohorts()
        {
            var loaded = Resources.LoadAll<LevelCohortSO>("cohorts");
            if (loaded == null || loaded.Length == 0)
            {
                _cohorts = new LevelCohortSO[0];
                _cohortNames = new string[0];
                return;
            }
            _cohorts = loaded.OrderBy(c => c.cohortName).ToArray();
            _cohortNames = _cohorts.Select(c => c.cohortName ?? c.name).ToArray();
            Debug.Log($"[LevelViewer3D] Loaded {_cohorts.Length} cohorts");
        }

        private void SelectCohort(int index)
        {
            _selectedCohortIndex = index;
            _selectedLevelIndex = 0;
            _levelListScroll = Vector2.zero;
            _searchFilter = "";
            SelectLevel(0);
        }

        private void SelectLevel(int index)
        {
            if (_cohorts == null || _selectedCohortIndex >= _cohorts.Length) return;
            var cohort = _cohorts[_selectedCohortIndex];
            if (cohort.levels == null || cohort.levels.Count == 0) return;

            var filteredLevels = GetFilteredLevels();
            if (index < 0 || index >= filteredLevels.Count) return;

            _selectedLevelIndex = index;
            _currentLevelData = filteredLevels[index];

            if (_currentLevelData == null)
            {
                _currentParsed = null;
                ClearLevel();
                return;
            }

            string levelName = _currentLevelData.name;
            var jsonAsset = Resources.Load<TextAsset>("levelmaps/" + levelName);
            if (jsonAsset != null)
            {
                _currentParsed = TiledMapParser.Parse(jsonAsset.text, levelName);
                BuildLevel3D();
                CenterCamera();
            }
            else
            {
                Debug.LogWarning($"[LevelViewer3D] No JSON found for level: {levelName}");
                _currentParsed = null;
                ClearLevel();
            }
        }

        private List<LevelDataSO> GetFilteredLevels()
        {
            var cohort = _cohorts[_selectedCohortIndex];
            if (cohort.levels == null) return new List<LevelDataSO>();
            if (string.IsNullOrEmpty(_searchFilter))
                return cohort.levels.Where(l => l != null).ToList();
            string filter = _searchFilter.ToLowerInvariant();
            return cohort.levels
                .Where(l => l != null && l.name.ToLowerInvariant().Contains(filter))
                .ToList();
        }

        // --- 3D Level Building ---

        private void ClearLevel()
        {
            if (_levelRoot != null)
            {
                Destroy(_levelRoot.gameObject);
                _levelRoot = null;
            }
        }

        private void BuildLevel3D()
        {
            ClearLevel();
            if (_currentParsed == null) return;

            var rootGO = new GameObject("Level_" + _currentParsed.LevelName);
            _levelRoot = rootGO.transform;

            int w = _currentParsed.Width;
            int h = _currentParsed.Height;

            // === 1. GRASS GROUND PLANE - fills the entire grid area ===
            CreateGroundPlane(w, h);

            // === 2. LAYER PARENTS ===
            var mapParent = new GameObject("MapLayer").transform;
            mapParent.SetParent(_levelRoot);
            var ldfParent = new GameObject("LdfLayer").transform;
            ldfParent.SetParent(_levelRoot);
            var spawnParent = new GameObject("SpawnLayer").transform;
            spawnParent.SetParent(_levelRoot);

            // === 3. BUILD LAYERS ===
            if (_showMapLayer && _currentParsed.MapData != null)
                BuildLayerObjects(_currentParsed.MapData, w, h, mapParent, 0.01f, true);

            if (_showLdfLayer && _currentParsed.LdfData != null)
                BuildLayerObjects(_currentParsed.LdfData, w, h, ldfParent, 0.02f, false);

            if (_showSpawnLayer)
            {
                float yOff = 0.03f;
                int spawnLayerCount = _showFirstSpawnWaveOnly ? Mathf.Min(1, _currentParsed.SpawnLayers.Count) : _currentParsed.SpawnLayers.Count;
                for (int i = 0; i < spawnLayerCount; i++)
                {
                    var spawnData = _currentParsed.SpawnLayers[i];
                    if (spawnData != null)
                    {
                        BuildSpawnLayerObjects(spawnData, i, w, h, spawnParent, yOff);
                        yOff += 0.01f;
                    }
                }
            }
        }

        private void CreateGroundPlane(int gridW, int gridH)
        {
            // Create a large green quad covering the entire level grid
            float margin = 1.5f;
            var groundGO = GameObject.CreatePrimitive(PrimitiveType.Quad);
            groundGO.name = "GrassGround";
            groundGO.transform.SetParent(_levelRoot);
            groundGO.transform.position = new Vector3(
                (gridW - 1) * 0.5f,
                -(gridH - 1) * 0.5f,
                0.03f
            );
            groundGO.transform.rotation = Quaternion.identity;
            groundGO.transform.localScale = new Vector3(gridW + margin * 2, gridH + margin * 2, 1f);

            var col = groundGO.GetComponent<Collider>();
            if (col != null) Destroy(col);

            var renderer = groundGO.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = _grassGroundMat;
                SetMatTextureScale(_grassGroundMat, new Vector2((gridW + margin * 2) / 2.56f, (gridH + margin * 2) / 2.56f));
            }
        }

        private void BuildLayerObjects(int[] data, int gridW, int gridH, Transform parent, float yOffset, bool isMapLayer)
        {
            for (int i = 0; i < data.Length && i < gridW * gridH; i++)
            {
                int tileId = data[i];
                if (tileId == 0) continue;

                int gx = i % gridW;
                int gy = i / gridW;

                // Match Sandbox: Tiled cell (x, y) is spawned at Unity (x, -y, z).
                float worldX = gx;
                float worldY = -gy;
                float worldZ = -yOffset;

                var tileInfo = TilePrefabMapping.Get(tileId);
                string resourcePath = _tileLookup != null ? _tileLookup.GetCoverPath(tileId) : tileInfo.CoverPrefabPath;

                // Try to load cover prefab
                GameObject prefab = null;
                if (!string.IsNullOrEmpty(resourcePath))
                    prefab = LoadPrefab(resourcePath);

                if (prefab != null)
                {
                    var instance = Instantiate(prefab, new Vector3(worldX, worldY, worldZ), Quaternion.identity, parent);
                    instance.name = $"{tileInfo.Name}_{gx}_{gy}";

                    if (_tileLookup != null && _tileLookup.TryGet(tileId, out var def) && Mathf.Abs(def.tunnelZRotation) > 0.001f)
                        instance.transform.rotation = Quaternion.Euler(0, 0, def.tunnelZRotation);

                    // Activate all children first
                    foreach (Transform child in instance.GetComponentsInChildren<Transform>(true))
                        child.gameObject.SetActive(true);

                    // Fix all materials to use URP-compatible shader
                    FixPrefabMaterials(instance);
                }
                else
                {
                    // Fallback: colored quad for tiles without prefab
                    CreateFallbackTile(tileId, worldX, worldY, worldZ - 0.005f, parent, gx, gy);
                }
            }
        }

        private void BuildSpawnLayerObjects(int[] data, int spawnLayerIndex, int gridW, int gridH, Transform parent, float yOffset)
        {
            var spawnKinds = BuildSpawnKindSequence(spawnLayerIndex);
            int spawnKindIndex = 0;
            bool limitToBatchCount = spawnKinds.Count > 0;

            for (int i = 0; i < data.Length && i < gridW * gridH; i++)
            {
                int tileId = data[i];
                if (tileId == 0) continue;

                int gx = i % gridW;
                int gy = i / gridW;
                float worldX = gx;
                float worldY = -gy;
                float worldZ = -yOffset;

                var displayInfo = _tileLookup != null ? _tileLookup.GetDisplayInfo(tileId) : TileIdMapping.Get(tileId);
                if (displayInfo.Category == TileDisplayCategory.PlayerStart)
                {
                    CreatePlayerStartVisual(worldX, worldY, worldZ, parent, gx, gy);
                    continue;
                }

                if (displayInfo.Category == TileDisplayCategory.PillSpawn || IsSpawnTileId(tileId))
                {
                    if (limitToBatchCount && spawnKindIndex >= spawnKinds.Count)
                        continue;

                    var kind = ResolveSpawnKind(tileId, spawnKinds, ref spawnKindIndex);
                    CreateFruitVisual(kind, worldX, worldY, worldZ, parent, gx, gy);
                    continue;
                }

                CreateFallbackTile(tileId, worldX, worldY, worldZ - 0.005f, parent, gx, gy);
            }
        }

        private List<PillKind> BuildSpawnKindSequence(int spawnLayerIndex)
        {
            var result = new List<PillKind>();
            var batches = _currentLevelData?.respawnSequence?.batches;
            if (batches == null || spawnLayerIndex < 0 || spawnLayerIndex >= batches.Count)
                return result;

            var colors = batches[spawnLayerIndex]?.colors;
            if (colors == null) return result;

            foreach (var color in colors)
            {
                if (color == null) continue;
                int count = Mathf.Max(0, color.count);
                for (int i = 0; i < count; i++)
                    result.Add(color.pillKind);
            }

            return result;
        }

        private static PillKind ResolveSpawnKind(int tileId, List<PillKind> spawnKinds, ref int spawnKindIndex)
        {
            if (spawnKinds != null && spawnKinds.Count > 0)
            {
                var kind = spawnKinds[spawnKindIndex % spawnKinds.Count];
                spawnKindIndex++;
                return kind;
            }

            if (tileId >= 371 && tileId <= 377)
                return (PillKind)(tileId - 371);

            return PillKind.Strawberry;
        }

        private static bool IsSpawnTileId(int tileId)
        {
            return tileId == 277 || (tileId >= 371 && tileId <= 377);
        }

        private void CreatePlayerStartVisual(float x, float y, float z, Transform parent, int gx, int gy)
        {
            var prefab = LoadEditorPrefabByName("SnakeHead");
            if (prefab != null)
            {
                var instance = Instantiate(prefab, new Vector3(x, y, z - 0.03f), Quaternion.identity, parent);
                instance.name = $"PlayerStart_{gx}_{gy}";
                instance.transform.localScale = Vector3.one * 0.45f;

                foreach (Transform child in instance.GetComponentsInChildren<Transform>(true))
                    child.gameObject.SetActive(true);

                FixPrefabMaterials(instance);
                return;
            }

            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = $"PlayerStart_{gx}_{gy}";
            go.transform.SetParent(parent);
            go.transform.position = new Vector3(x, y, z - 0.03f);
            go.transform.localScale = new Vector3(0.55f, 0.45f, 0.18f);
            ApplyRuntimeMaterial(go, new Color(0.55f, 0.32f, 0.82f, 1f), "PlayerStartMat");
            AddLabel(go.transform, "P", Color.white, -0.08f);
        }

        private void CreateFruitVisual(PillKind kind, float x, float y, float z, Transform parent, int gx, int gy)
        {
            var prefab = LoadEditorPrefabByName("PillMaster");
            if (prefab != null)
            {
                var instance = Instantiate(prefab, new Vector3(x, y, z - 0.08f), Quaternion.identity, parent);
                instance.name = $"Pill_{kind}_{gx}_{gy}";
                instance.transform.localScale = Vector3.one;
                FixPrefabMaterials(instance);
                ActivatePillKind(instance, kind);
                return;
            }

            var mesh = LoadFruitMesh(kind);
            var go = new GameObject($"Spawn_{kind}_{gx}_{gy}");
            go.transform.SetParent(parent);
            go.transform.position = new Vector3(x, y, z - 0.04f);
            go.transform.localScale = Vector3.one * 0.36f;

            if (mesh != null)
            {
                var mf = go.AddComponent<MeshFilter>();
                mf.sharedMesh = mesh;
                var mr = go.AddComponent<MeshRenderer>();
                mr.sharedMaterial = GetFruitMaterial(kind);
            }
            else
            {
                var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = "FallbackFruitMesh";
                sphere.transform.SetParent(go.transform, false);
                sphere.transform.localScale = Vector3.one;
                ApplyRuntimeMaterial(sphere, GetPillColor(kind), $"Fruit_{kind}_Mat");
            }
        }

        private static void ActivatePillKind(GameObject instance, PillKind kind)
        {
            var shapes = instance.GetComponentsInChildren<PillColorShape>(true);

            foreach (var shape in shapes)
                shape.gameObject.SetActive(false);

            foreach (var transform in instance.GetComponentsInChildren<Transform>(true))
            {
                if (transform.name == "Calibrators" || transform.name == "SecreteCollectibleParent")
                    transform.gameObject.SetActive(false);
            }

            foreach (var shape in shapes)
            {
                if (shape.pillKind != kind) continue;

                shape.gameObject.SetActive(true);
                ActivateParentsUntil(shape.transform, instance.transform);
                DisableRendererOnShapeRoot(shape);
            }
        }

        private static void DisableRendererOnShapeRoot(PillColorShape shape)
        {
            var renderer = shape.GetComponent<Renderer>();
            if (renderer != null)
                renderer.enabled = false;
        }

        private static void ActivateParentsUntil(Transform child, Transform root)
        {
            var current = child.parent;
            while (current != null && current != root.parent)
            {
                current.gameObject.SetActive(true);
                if (current == root) break;
                current = current.parent;
            }
        }

        private Mesh LoadFruitMesh(PillKind kind)
        {
            if (_fruitMeshCache.TryGetValue(kind, out var cached))
                return cached;

            Mesh mesh = null;
#if UNITY_EDITOR
            string[] paths = GetFruitMeshPaths(kind);
            foreach (var path in paths)
            {
                mesh = AssetDatabase.LoadAssetAtPath<Mesh>(path);
                if (mesh != null) break;
            }
#endif
            _fruitMeshCache[kind] = mesh;
            return mesh;
        }

        private Material GetFruitMaterial(PillKind kind)
        {
            if (_fruitMatCache.TryGetValue(kind, out var cached))
                return cached;

            var mat = new Material(_unlitShader);
            mat.name = $"Fruit_{kind}_Runtime";
            SetMatColor(mat, GetPillColor(kind));
            SetCullOff(mat);
            _fruitMatCache[kind] = mat;
            _runtimeMats.Add(mat);
            return mat;
        }

        private static string[] GetFruitMeshPaths(PillKind kind)
        {
            switch (kind)
            {
                case PillKind.Strawberry: return new[] { "Assets/Mesh/FruitMesh_Strawberry_red.asset" };
                case PillKind.Blueberry: return new[] { "Assets/Mesh/FruitMesh_Blueberry.asset" };
                case PillKind.Banana: return new[] { "Assets/Mesh/Fruit_BananaV2.asset", "Assets/Mesh/FruitMesh_Banana.asset" };
                case PillKind.Pear: return new[] { "Assets/Mesh/Fruit_PearV2.asset", "Assets/Mesh/FruitMesh_Pear_yellow.asset" };
                case PillKind.Apple: return new[] { "Assets/Mesh/FruitMesh_Apple.asset" };
                case PillKind.Carrot: return new[] { "Assets/Mesh/FruitMesh_Carrot.asset", "Assets/Mesh/Carrot.asset" };
                case PillKind.Eggplant: return new[] { "Assets/Mesh/FruitMesh_Eggplant.asset" };
                default: return new string[0];
            }
        }

        private static Color GetPillColor(PillKind kind)
        {
            switch (kind)
            {
                case PillKind.Strawberry: return new Color(0.95f, 0.12f, 0.24f, 1f);
                case PillKind.Blueberry: return new Color(0.17f, 0.32f, 0.85f, 1f);
                case PillKind.Banana: return new Color(0.98f, 0.78f, 0.18f, 1f);
                case PillKind.Pear: return new Color(0.74f, 0.9f, 0.27f, 1f);
                case PillKind.Apple: return new Color(0.35f, 0.78f, 0.2f, 1f);
                case PillKind.Carrot: return new Color(0.98f, 0.45f, 0.08f, 1f);
                case PillKind.Eggplant: return new Color(0.55f, 0.18f, 0.82f, 1f);
                default: return Color.white;
            }
        }

        private static string GetPillShortLabel(PillKind kind)
        {
            switch (kind)
            {
                case PillKind.Strawberry: return "S";
                case PillKind.Blueberry: return "B";
                case PillKind.Banana: return "Ba";
                case PillKind.Pear: return "Pe";
                case PillKind.Apple: return "A";
                case PillKind.Carrot: return "C";
                case PillKind.Eggplant: return "E";
                default: return "?";
            }
        }

        private void ApplyRuntimeMaterial(GameObject target, Color color, string materialName)
        {
            var renderer = target.GetComponent<Renderer>();
            if (renderer == null) return;

            var mat = new Material(_unlitShader);
            mat.name = materialName;
            SetMatColor(mat, color);
            SetCullOff(mat);
            renderer.sharedMaterial = mat;
            _runtimeMats.Add(mat);
        }

        private void AddLabel(Transform parent, string text, Color color, float localY)
        {
            var labelGo = new GameObject("Label");
            labelGo.transform.SetParent(parent, false);
            labelGo.transform.localPosition = new Vector3(0, localY, -0.12f);
            labelGo.transform.localRotation = Quaternion.identity;
            labelGo.transform.localScale = Vector3.one * 0.12f;

            var label = labelGo.AddComponent<TextMesh>();
            label.text = text;
            label.anchor = TextAnchor.MiddleCenter;
            label.alignment = TextAlignment.Center;
            label.fontSize = 32;
            label.color = color;
        }

        private GameObject LoadPrefab(string resourcePath)
        {
            if (_prefabCache.TryGetValue(resourcePath, out var cached))
                return cached;

            var prefab = Resources.Load<GameObject>(resourcePath);

            // Resources.Load is case-insensitive on Windows, but try lowercase anyway
            if (prefab == null)
            {
                string lower = resourcePath.ToLowerInvariant();
                if (lower != resourcePath)
                    prefab = Resources.Load<GameObject>(lower);
            }

            _prefabCache[resourcePath] = prefab;

            if (prefab == null)
                Debug.LogWarning($"[LevelViewer3D] Prefab not found: {resourcePath}");

            return prefab;
        }

        private GameObject LoadEditorPrefabByName(string prefabName)
        {
            if (_editorPrefabCache.TryGetValue(prefabName, out var cached))
                return cached;

            GameObject prefab = null;
#if UNITY_EDITOR
            var guids = AssetDatabase.FindAssets($"{prefabName} t:Prefab");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (!path.EndsWith(prefabName + ".prefab")) continue;
                prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (prefab != null) break;
            }
#endif
            _editorPrefabCache[prefabName] = prefab;
            return prefab;
        }

        private void CreateFallbackTile(int tileId, float x, float y, float z, Transform parent, int gx, int gy)
        {
            var displayInfo = _tileLookup != null ? _tileLookup.GetDisplayInfo(tileId) : TileIdMapping.Get(tileId);

            var go = GameObject.CreatePrimitive(PrimitiveType.Quad);
            go.name = $"FB_{displayInfo.Name}_{gx}_{gy}";
            go.transform.SetParent(parent);
            go.transform.position = new Vector3(x, y, z);
            go.transform.rotation = Quaternion.identity;
            go.transform.localScale = new Vector3(0.7f, 0.7f, 1f);

            var col = go.GetComponent<Collider>();
            if (col != null) Destroy(col);

            var renderer = go.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                var mat = new Material(_fallbackMatTemplate);
                mat.name = $"FallbackMat_{displayInfo.Name}";
                Color c = new Color(displayInfo.Color.r / 255f, displayInfo.Color.g / 255f,
                                    displayInfo.Color.b / 255f, 1f);
                SetMatColor(mat, c);
                SetCullOff(mat);
                renderer.sharedMaterial = mat;
                _runtimeMats.Add(mat);
            }
        }

        // --- OnGUI ---

        private void BuildStyles()
        {
            if (_stylesBuilt) return;
            _stylesBuilt = true;

            _headerStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 20, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter
            };
            _headerStyle.normal.textColor = new Color(0.95f, 0.92f, 0.8f);

            _subHeaderStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 13, fontStyle = FontStyle.Bold
            };
            _subHeaderStyle.normal.textColor = new Color(0.8f, 0.8f, 0.9f);

            _levelBtnStyle = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleLeft, fontSize = 11,
                fixedHeight = 24, padding = new RectOffset(8, 4, 2, 2)
            };

            _levelBtnSelectedStyle = new GUIStyle(_levelBtnStyle);
            _levelBtnSelectedStyle.normal.textColor = Color.yellow;
            _levelBtnSelectedStyle.fontStyle = FontStyle.Bold;

            _boxStyle = new GUIStyle(GUI.skin.box) { padding = new RectOffset(8, 8, 8, 8) };
            _legendStyle = new GUIStyle(GUI.skin.label) { fontSize = 10, padding = new RectOffset(2, 2, 1, 1) };
            _smallLabelStyle = new GUIStyle(GUI.skin.label) { fontSize = 11 };
        }

        private void OnGUI()
        {
            if (!_initialized) return;
            BuildStyles();

            float sw = Screen.width;
            float sh = Screen.height;
            float leftW = 240;
            float rightW = 260;
            float headerH = 36;

            GUI.Box(new Rect(0, 0, sw, headerH), "");
            GUI.Label(new Rect(0, 0, sw, headerH), "\ud83c\udfae SNACKY DASH - 3D Level Viewer", _headerStyle);

            float contentY = headerH;
            float contentH = sh - headerH;

            DrawLeftPanel(new Rect(0, contentY, leftW, contentH));
            DrawRightPanel(new Rect(sw - rightW, contentY, rightW, contentH));

            if (_currentParsed != null)
            {
                var hintStyle = new GUIStyle(GUI.skin.label)
                {
                    alignment = TextAnchor.LowerCenter, fontSize = 11
                };
                hintStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
                GUI.Label(new Rect(leftW, sh - 30, sw - leftW - rightW, 25),
                    "Scroll=Zoom | RMB Drag=Pan | F=Center", hintStyle);
            }
        }

        private void DrawLeftPanel(Rect area)
        {
            GUILayout.BeginArea(area, _boxStyle);

            GUILayout.Label("COHORT", _subHeaderStyle);
            if (_cohortNames != null && _cohortNames.Length > 0)
            {
                int newIdx = EditorLikePopup(_selectedCohortIndex, _cohortNames);
                if (newIdx != _selectedCohortIndex) SelectCohort(newIdx);
            }
            GUILayout.Space(6);

            GUILayout.Label("Search:", _smallLabelStyle);
            string newSearch = GUILayout.TextField(_searchFilter, GUILayout.Height(22));
            if (newSearch != _searchFilter)
            {
                _searchFilter = newSearch;
                _selectedLevelIndex = 0;
            }
            GUILayout.Space(4);

            var filtered = GetFilteredLevels();
            int playerLevel = GetCohortLevelNumber(_currentLevelData);
            GUILayout.Label($"Levels: {filtered.Count}  |  Lv. {playerLevel}", _smallLabelStyle);
            GUILayout.Space(4);

            _levelListScroll = GUILayout.BeginScrollView(_levelListScroll, false, true);
            for (int i = 0; i < filtered.Count; i++)
            {
                var level = filtered[i];
                string label = FormatLevelLabel(level);
                bool isSelected = (i == _selectedLevelIndex);
                var style = isSelected ? _levelBtnSelectedStyle : _levelBtnStyle;
                if (GUILayout.Button((isSelected ? "\u25ba " : "  ") + label, style))
                    SelectLevel(i);
            }
            GUILayout.EndScrollView();
            GUILayout.Space(4);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("\u25c4 Prev", GUILayout.Height(28)))
                if (_selectedLevelIndex > 0) SelectLevel(_selectedLevelIndex - 1);
            if (GUILayout.Button("Next \u25ba", GUILayout.Height(28)))
                if (_selectedLevelIndex < filtered.Count - 1) SelectLevel(_selectedLevelIndex + 1);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("\u25c4\u25c4 -10", GUILayout.Height(22)))
                SelectLevel(Mathf.Max(0, _selectedLevelIndex - 10));
            if (GUILayout.Button("+10 \u25ba\u25ba", GUILayout.Height(22)))
                SelectLevel(Mathf.Min(filtered.Count - 1, _selectedLevelIndex + 10));
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        private void DrawRightPanel(Rect area)
        {
            GUILayout.BeginArea(area, _boxStyle);
            _infoScroll = GUILayout.BeginScrollView(_infoScroll);

            GUILayout.Label("LEVEL INFO", _subHeaderStyle);
            GUILayout.Space(4);

            if (_currentLevelData != null)
            {
                InfoRow("Name", _currentLevelData.name);
                InfoRow("Player Level", GetCohortLevelNumber(_currentLevelData).ToString());
                InfoRow("Crates", _currentLevelData.cratesTotal.ToString());
                InfoRow("Difficulty", _currentLevelData.difficulty.ToString());
                InfoRow("Diff Score", _currentLevelData.difficultyScore.ToString());
                InfoRow("Speed", _currentLevelData.speedPlayer.ToString("F1"));
                InfoRow("Rising Block", _currentLevelData.risingBlockDeliveriesToLower.ToString());
                InfoRow("Wall HP", _currentLevelData.destructibleWallHealth.ToString());
                InfoRow("Seed Random", _currentLevelData.usingSeedRandom ? _currentLevelData.seedRandom.ToString() : "Off");
            }

            if (_currentParsed != null)
            {
                GUILayout.Space(4);
                InfoRow("Grid", $"{_currentParsed.Width} \u00d7 {_currentParsed.Height}");
                InfoRow("Spawn Layers", _currentParsed.SpawnLayers.Count.ToString());
            }

            GUILayout.Space(10);
            GUILayout.Label("LAYERS", _subHeaderStyle);
            bool newMap = GUILayout.Toggle(_showMapLayer, " Map Layer");
            bool newLdf = GUILayout.Toggle(_showLdfLayer, " LDF Layer (Obstacles)");
            bool newSpawn = GUILayout.Toggle(_showSpawnLayer, " Spawn Layers");
            bool newFirstWaveOnly = GUILayout.Toggle(_showFirstSpawnWaveOnly, " First Spawn Wave Only");
            if (newMap != _showMapLayer || newLdf != _showLdfLayer || newSpawn != _showSpawnLayer || newFirstWaveOnly != _showFirstSpawnWaveOnly)
            {
                _showMapLayer = newMap;
                _showLdfLayer = newLdf;
                _showSpawnLayer = newSpawn;
                _showFirstSpawnWaveOnly = newFirstWaveOnly;
                BuildLevel3D();
            }

            GUILayout.Space(10);

            if (_currentParsed?.MapData != null)
            {
                GUILayout.Label("TILE STATS", _subHeaderStyle);
                var stats = new Dictionary<TileDisplayCategory, int>();
                CountTiles(_currentParsed.MapData, stats);
                if (_currentParsed.LdfData != null) CountTiles(_currentParsed.LdfData, stats);

                foreach (var kv in stats.OrderByDescending(x => x.Value))
                {
                    var col = TileIdMapping.GetCategoryColor(kv.Key);
                    var oldColor = GUI.color;
                    GUI.color = new Color(col.r / 255f, col.g / 255f, col.b / 255f);
                    GUILayout.Label($"\u25a0 {kv.Key}: {kv.Value}", _legendStyle);
                    GUI.color = oldColor;
                }
            }

            GUILayout.Space(8);

            if (_cohorts != null && _selectedCohortIndex < _cohorts.Length)
            {
                var c = _cohorts[_selectedCohortIndex];
                GUILayout.Label("COHORT INFO", _subHeaderStyle);
                InfoRow("Name", c.cohortName);
                InfoRow("Total Levels", c.levels != null ? c.levels.Count.ToString() : "0");
                InfoRow("Is Loop", c.isLoop.ToString());
                InfoRow("Loop Start", c.loopStartIndex.ToString());
            }

            GUILayout.Space(10);
            GUILayout.Label("CAMERA", _subHeaderStyle);
            GUILayout.Label($"Zoom: {_cameraZoom:F1}", _smallLabelStyle);
            if (GUILayout.Button("Reset Camera (F)", GUILayout.Height(24)))
                CenterCamera();

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private static void CountTiles(int[] data, Dictionary<TileDisplayCategory, int> stats)
        {
            foreach (int tid in data)
            {
                if (tid == 0) continue;
                var info = TileIdMapping.Get(tid);
                if (!stats.ContainsKey(info.Category)) stats[info.Category] = 0;
                stats[info.Category]++;
            }
        }

        private int GetCohortLevelNumber(LevelDataSO level)
        {
            if (level == null || _cohorts == null || _selectedCohortIndex < 0 || _selectedCohortIndex >= _cohorts.Length)
                return 0;

            var levels = _cohorts[_selectedCohortIndex].levels;
            if (levels == null) return 0;

            int index = levels.IndexOf(level);
            return index >= 0 ? index + 1 : _selectedLevelIndex + 1;
        }

        private string FormatLevelLabel(LevelDataSO level)
        {
            if (level == null) return "(null)";
            return $"Lv {GetCohortLevelNumber(level):000}  {level.name}";
        }

        private void InfoRow(string label, string value)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label + ":", _smallLabelStyle, GUILayout.Width(100));
            GUILayout.Label(value, _smallLabelStyle);
            GUILayout.EndHorizontal();
        }

        private int EditorLikePopup(int selected, string[] options)
        {
            GUILayout.BeginHorizontal();
            string current = selected >= 0 && selected < options.Length ? options[selected] : "---";
            GUILayout.Label(current, GUI.skin.textField, GUILayout.Height(22));
            if (GUILayout.Button("\u25c4", GUILayout.Width(25), GUILayout.Height(22)))
                selected = Mathf.Max(0, selected - 1);
            if (GUILayout.Button("\u25ba", GUILayout.Width(25), GUILayout.Height(22)))
                selected = Mathf.Min(options.Length - 1, selected + 1);
            GUILayout.EndHorizontal();
            return selected;
        }

        private void OnDestroy()
        {
            ClearLevel();
            if (_grassGroundMat != null) Destroy(_grassGroundMat);
            if (_fallbackMatTemplate != null) Destroy(_fallbackMatTemplate);

            // Clean up all runtime-created replacement materials
            foreach (var mat in _runtimeMats)
                if (mat != null) Destroy(mat);
            _runtimeMats.Clear();
            _fixedMatCache.Clear();
        }
    }
}
