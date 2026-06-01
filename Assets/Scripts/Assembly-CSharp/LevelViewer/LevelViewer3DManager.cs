using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        private Camera _mainCamera;
        private Material _grassGroundMat;
        private Material _fallbackMatTemplate;

        // --- Material Fix System ---
        private Shader _unlitShader;
        private readonly Dictionary<Material, Material> _fixedMatCache = new Dictionary<Material, Material>();
        private readonly List<Material> _runtimeMats = new List<Material>();

        // --- UI State ---
        private Vector2 _levelListScroll;
        private Vector2 _infoScroll;
        private bool _showMapLayer = true;
        private bool _showLdfLayer = true;
        private bool _showSpawnLayer;
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
            if (_mainCamera == null) _mainCamera = FindObjectOfType<Camera>();

            // Setup camera for top-down orthographic view
            if (_mainCamera != null)
            {
                _mainCamera.orthographic = true;
                _mainCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
                _mainCamera.orthographicSize = _cameraZoom;
                _mainCamera.backgroundColor = BG_COLOR;
                _mainCamera.clearFlags = CameraClearFlags.SolidColor;
                _mainCamera.nearClipPlane = -50;
                _mainCamera.farClipPlane = 100;
            }

            // Prepare shared materials
            PrepareMaterials();

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

            _fallbackMatTemplate = new Material(_unlitShader);
            _fallbackMatTemplate.name = "FallbackMat_Runtime";
        }

        /// <summary>
        /// After a prefab is instantiated, replace every material on every renderer
        /// with a clean URP/Unlit material that copies color from the original.
        /// This bypasses all shader compatibility issues.
        /// </summary>
        private void FixPrefabMaterials(GameObject instance)
        {
            if (_unlitShader == null) return;

            foreach (var renderer in instance.GetComponentsInChildren<Renderer>(true))
            {
                if (renderer == null) continue;

                var mats = renderer.sharedMaterials;
                bool changed = false;
                var newMats = new Material[mats.Length];

                for (int m = 0; m < mats.Length; m++)
                {
                    var orig = mats[m];
                    if (orig == null)
                    {
                        newMats[m] = _fallbackMatTemplate;
                        changed = true;
                        continue;
                    }

                    // Check if shader is already a known-good URP shader
                    string shaderName = orig.shader != null ? orig.shader.name : "";
                    bool isGoodShader = shaderName.StartsWith("Universal Render Pipeline/")
                                     || shaderName.StartsWith("Unlit/")
                                     || shaderName == "Sprites/Default";

                    if (isGoodShader)
                    {
                        newMats[m] = orig;
                        continue;
                    }

                    // Check cache
                    if (_fixedMatCache.TryGetValue(orig, out var cached))
                    {
                        newMats[m] = cached;
                        changed = true;
                        continue;
                    }

                    // Create replacement URP/Unlit material
                    var replacement = new Material(_unlitShader);
                    replacement.name = orig.name + "_URPFixed";

                    // Extract the best color from the original material properties
                    Color color = ExtractColorFromMaterial(orig);
                    SetMatColor(replacement, color);

                    _fixedMatCache[orig] = replacement;
                    _runtimeMats.Add(replacement);
                    newMats[m] = replacement;
                    changed = true;
                }

                if (changed)
                    renderer.sharedMaterials = newMats;

                // Always enable renderer
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
                    _mainCamera.orthographicSize = _cameraZoom;
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
                _mainCamera.transform.position -= new Vector3(delta.x * panSpeed, 0, delta.y * panSpeed);
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetKeyDown(KeyCode.F) && _currentParsed != null)
                CenterCamera();
        }

        private void CenterCamera()
        {
            if (_mainCamera == null || _currentParsed == null) return;
            float centerX = _currentParsed.Width * 0.5f;
            float centerZ = _currentParsed.Height * 0.5f;
            _mainCamera.transform.position = new Vector3(centerX, 20, centerZ);
            _cameraZoom = Mathf.Max(_currentParsed.Width, _currentParsed.Height) * 0.6f;
            _mainCamera.orthographicSize = _cameraZoom;
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
                foreach (var spawnData in _currentParsed.SpawnLayers)
                {
                    if (spawnData != null)
                    {
                        BuildLayerObjects(spawnData, w, h, spawnParent, yOff, false);
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
                -0.01f,
                (gridH - 1) * 0.5f
            );
            groundGO.transform.rotation = Quaternion.Euler(90, 0, 0);
            groundGO.transform.localScale = new Vector3(gridW + margin * 2, gridH + margin * 2, 1f);

            var col = groundGO.GetComponent<Collider>();
            if (col != null) Destroy(col);

            var renderer = groundGO.GetComponent<MeshRenderer>();
            if (renderer != null) renderer.sharedMaterial = _grassGroundMat;
        }

        private void BuildLayerObjects(int[] data, int gridW, int gridH, Transform parent, float yOffset, bool isMapLayer)
        {
            for (int i = 0; i < data.Length && i < gridW * gridH; i++)
            {
                int tileId = data[i];
                if (tileId == 0) continue;

                int gx = i % gridW;
                int gy = i / gridW;

                // Tiled: top-left origin. Unity XZ plane, flip Y.
                float worldX = gx;
                float worldZ = (gridH - 1 - gy);
                float worldY = yOffset;

                var tileInfo = TilePrefabMapping.Get(tileId);

                // Try to load cover prefab
                GameObject prefab = null;
                if (!string.IsNullOrEmpty(tileInfo.CoverPrefabPath))
                    prefab = LoadPrefab(tileInfo.CoverPrefabPath);

                if (prefab != null)
                {
                    var instance = Instantiate(prefab, new Vector3(worldX, worldY, worldZ), Quaternion.identity, parent);
                    instance.name = $"{tileInfo.Name}_{gx}_{gy}";

                    // Activate all children first
                    foreach (Transform child in instance.GetComponentsInChildren<Transform>(true))
                        child.gameObject.SetActive(true);

                    // Fix all materials to use URP-compatible shader
                    FixPrefabMaterials(instance);
                }
                else
                {
                    // Fallback: colored quad for tiles without prefab
                    CreateFallbackTile(tileId, worldX, worldY + 0.005f, worldZ, parent, gx, gy);
                }
            }
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

        private void CreateFallbackTile(int tileId, float x, float y, float z, Transform parent, int gx, int gy)
        {
            var displayInfo = TileIdMapping.Get(tileId);

            var go = GameObject.CreatePrimitive(PrimitiveType.Quad);
            go.name = $"FB_{displayInfo.Name}_{gx}_{gy}";
            go.transform.SetParent(parent);
            go.transform.position = new Vector3(x, y, z);
            go.transform.rotation = Quaternion.Euler(90, 0, 0);
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
            GUILayout.Label($"Levels: {filtered.Count}  |  #{_selectedLevelIndex + 1}", _smallLabelStyle);
            GUILayout.Space(4);

            _levelListScroll = GUILayout.BeginScrollView(_levelListScroll, false, true);
            for (int i = 0; i < filtered.Count; i++)
            {
                var level = filtered[i];
                string label = level != null ? level.name : "(null)";
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
            if (newMap != _showMapLayer || newLdf != _showLdfLayer || newSpawn != _showSpawnLayer)
            {
                _showMapLayer = newMap;
                _showLdfLayer = newLdf;
                _showSpawnLayer = newSpawn;
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
