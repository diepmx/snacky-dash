using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameplaySandbox : MonoBehaviour
{
    [Header("Level Configuration")]
    [Tooltip("Tên file JSON màn chơi trong Resources/levelmaps/ (ví dụ: 11004_v1). Để trống để tự động load level đầu tiên của cohort.")]
    public string levelMapName = "";
    public bool useCohortOrder = true;
    public string cohortResourceName = "test-a-co";

    [Header("Sandbox Viewer")]
    public Camera targetCamera;
    public float cameraPadding = 1.5f;
    public bool showLevelSwitcher = true;
    public bool showLevelInfo = true;

    [Header("Background")]
    public bool showGameBackground = true;
    public Color gameBackgroundColor = new Color(0.58310264f, 1f, 0.5424528f, 1f);
    public Color grassBackgroundColor = new Color(0.38f, 0.72f, 0.28f, 1f);
    public float backgroundMargin = 20f;
    [Tooltip("Gán sẵn GameObject Ground_BG trong scene để thay thế material trực tiếp. Nếu để trống sẽ tự động tạo Quad lúc runtime.")]
    public MeshRenderer backgroundOverride;

    [Header("Prefabs & Resources")]
    public GameObject snakeHeadPrefab;
    public GameObject snakeTailPrefab;
    public GameObject pillPrefab;

    [Header("Gameplay Parameters")]
    public float moveSpeed = 8f;

    // Định nghĩa cấu trúc JSON cho Tiled Map
    [Serializable]
    public class TiledLayer
    {
        public int[] data;
        public string name;
        public int width;
        public int height;
    }

    [Serializable]
    public class TiledMap
    {
        public int width;
        public int height;
        public List<TiledLayer> layers;
        public List<TiledTileset> tilesets;
    }

    [Serializable]
    public class TiledTileset
    {
        public int firstgid = 1;
        public string source;
    }

    private TiledMap activeMap;
    private Dictionary<Vector2Int, int> gridMap = new Dictionary<Vector2Int, int>();
    private Dictionary<Vector2Int, int> spawnMap = new Dictionary<Vector2Int, int>();
    private Dictionary<int, string> tiledIdToResourcePath = new Dictionary<int, string>();
    private Dictionary<Vector2Int, GameObject> spawnedPills = new Dictionary<Vector2Int, GameObject>();
    private int tilesetFirstGid = 1;
    private GameObject boardContainer;
    private GameObject backgroundContainer;
    private Material backgroundMaterial;
    private LevelCohortSO activeCohort;
    private LevelDataSO[] availableLevelData = new LevelDataSO[0];
    private LevelDataSO currentLevelData;
    private string[] availableLevelNames = new string[0];
    private int selectedLevelIndex = -1;
    private string levelInput = "";

    // Cohort switching
    private LevelCohortSO[] allCohorts = new LevelCohortSO[0];
    private int activeCohortIndex = 0;

    // Fruit spawn - wave 1
    private List<PillKind> wave1SpawnKinds = new List<PillKind>();
    private int wave1SpawnKindIndex = 0;
    private readonly Dictionary<string, GameObject> prefabCache = new Dictionary<string, GameObject>();
    private Shader unlitShader;
    private readonly List<Material> runtimeFruitMats = new List<Material>();

    // Trạng thái Rắn
    private GameObject snakeHead;
    private Vector2Int snakeGridPos;
    private Vector2Int targetGridPos;
    private bool isMoving = false;
    private Vector2Int moveDir = Vector2Int.zero;

    // Quản lý Đuôi (Tail Manager)
    private List<Vector2Int> snakePositionsHistory = new List<Vector2Int>();
    private List<GameObject> tailSegments = new List<GameObject>();
    private int requiredTailLength = 3; // Chiều dài đuôi mặc định ban đầu

    // Hệ thống Hầm chui (Tunnels)
    // Map lưu danh sách các cell hầm chui theo tunnelIndex (0, 1, 2, 3...)
    private Dictionary<int, List<Vector2Int>> tunnelPairs = new Dictionary<int, List<Vector2Int>>();
    // Lưu hướng thoát của hầm chui
    private Dictionary<Vector2Int, Vector2Int> tunnelExitDirections = new Dictionary<Vector2Int, Vector2Int>();

    // Xử lý Vuốt (Swipe Detection)
    private Vector2 touchStartPos;
    private bool isSwipeDetected = false;

    private void Awake()
    {
        // 1. Tự động parse YAML database để có map GID -> ResourcePath
        ParseTileDefinitionDatabase();
        LoadAvailableLevelNames();
    }

    private void Start()
    {
        // 2. Load và tạo Level
        levelInput = levelMapName;
        LoadLevel();
    }

    private void Update()
    {
        // 3. Nhận diện thao tác điều khiển
        HandleInput();
        HandleSandboxShortcuts();
    }

    // 1. Tự động parse YAML Database
    private void LoadAvailableLevelNames()
    {
        // Load toàn bộ cohort list
        LevelCohortSO[] loadedCohorts = Resources.LoadAll<LevelCohortSO>("cohorts");
        if (loadedCohorts != null && loadedCohorts.Length > 0)
        {
            // Sort theo tên để nhất quán
            System.Array.Sort(loadedCohorts, (a, b) => string.CompareOrdinal(a != null ? a.name : "", b != null ? b.name : ""));
            allCohorts = loadedCohorts;
        }

        TextAsset[] levelMaps = Resources.LoadAll<TextAsset>("levelmaps");
        List<string> names = new List<string>();
        List<LevelDataSO> levelData = new List<LevelDataSO>();

        activeCohort = LoadConfiguredCohort();

        // Sync activeCohortIndex với activeCohort
        if (activeCohort != null && allCohorts.Length > 0)
        {
            for (int i = 0; i < allCohorts.Length; i++)
            {
                if (allCohorts[i] == activeCohort)
                {
                    activeCohortIndex = i;
                    break;
                }
            }
        }

        if (useCohortOrder && activeCohort != null && activeCohort.levels != null && activeCohort.levels.Count > 0)
        {
            foreach (LevelDataSO level in activeCohort.levels)
            {
                if (level == null)
                {
                    continue;
                }

                names.Add(level.name);
                levelData.Add(level);
            }

            availableLevelNames = names.ToArray();
            availableLevelData = levelData.ToArray();

            // Nếu levelMapName rỗng hoặc không tìm thấy → start tại level đầu tiên
            selectedLevelIndex = Array.IndexOf(availableLevelNames, levelMapName);
            if (selectedLevelIndex < 0 && availableLevelNames.Length > 0)
            {
                selectedLevelIndex = 0;
                levelMapName = availableLevelNames[0];
            }
            return;
        }

        foreach (TextAsset levelMap in levelMaps)
        {
            if (levelMap != null)
            {
                names.Add(levelMap.name);
                levelData.Add(null);
            }
        }

        names.Sort(CompareLevelNames);
        availableLevelNames = names.ToArray();
        availableLevelData = new LevelDataSO[availableLevelNames.Length];
        selectedLevelIndex = Array.IndexOf(availableLevelNames, levelMapName);
        if (selectedLevelIndex < 0 && availableLevelNames.Length > 0)
        {
            selectedLevelIndex = 0;
            levelMapName = availableLevelNames[0];
        }
    }

    private LevelCohortSO LoadConfiguredCohort()
    {
        if (!useCohortOrder)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(cohortResourceName))
        {
            LevelCohortSO cohort = Resources.Load<LevelCohortSO>("cohorts/" + cohortResourceName.Trim());
            if (cohort != null)
            {
                return cohort;
            }
        }

        // Fallback: dùng cohort đầu tiên tìm được
        LevelCohortSO[] cohorts = Resources.LoadAll<LevelCohortSO>("cohorts");
        if (cohorts != null && cohorts.Length > 0)
        {
            // Ưu tiên tìm đúng tên
            foreach (LevelCohortSO cohort in cohorts)
            {
                if (cohort == null) continue;
                if (string.Equals(cohort.name, cohortResourceName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(cohort.cohortName, cohortResourceName, StringComparison.OrdinalIgnoreCase))
                {
                    return cohort;
                }
            }
            Debug.LogWarning($"Sandbox cohort '{cohortResourceName}' was not found. Falling back to first available cohort.");
            return cohorts[0];
        }

        Debug.LogWarning("No cohorts found in Resources/cohorts/. Falling back to sorted levelmaps.");
        return null;
    }

    /// <summary>
    /// Đổi sang cohort khác theo delta (-1 = prev, +1 = next), reset về level đầu tiên.
    /// </summary>
    private void SwitchCohort(int delta)
    {
        if (allCohorts == null || allCohorts.Length == 0) return;

        activeCohortIndex = Mathf.Clamp(activeCohortIndex + delta, 0, allCohorts.Length - 1);
        LevelCohortSO targetCohort = allCohorts[activeCohortIndex];
        if (targetCohort == null) return;

        cohortResourceName = targetCohort.name;
        activeCohort = targetCohort;

        // Rebuild level list từ cohort mới
        List<string> names = new List<string>();
        List<LevelDataSO> levelData = new List<LevelDataSO>();
        foreach (LevelDataSO level in activeCohort.levels)
        {
            if (level == null) continue;
            names.Add(level.name);
            levelData.Add(level);
        }
        availableLevelNames = names.ToArray();
        availableLevelData = levelData.ToArray();

        // Reset về level đầu tiên
        selectedLevelIndex = 0;
        if (availableLevelNames.Length > 0)
        {
            levelMapName = availableLevelNames[0];
            LoadLevel();
        }
    }

    private void ParseTileDefinitionDatabase()
    {
        string dbPath = Path.Combine(Application.dataPath, "MonoBehaviour/TileDefinitionDatabase.asset");
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Không tìm thấy file Database tại: " + dbPath);
            return;
        }

        string[] lines = File.ReadAllLines(dbPath);
        int currentId = -1;
        int currentTunnelIndex = -1;
        Vector2Int currentTunnelDir = Vector2Int.zero;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (line.StartsWith("tiledId:"))
            {
                int.TryParse(line.Replace("tiledId:", "").Trim(), out currentId);
            }
            else if (line.StartsWith("coverPrefabResourcePath:"))
            {
                string path = line.Replace("coverPrefabResourcePath:", "").Trim();
                if (currentId != -1 && !string.IsNullOrEmpty(path) && path != "~" && path != "null")
                {
                    tiledIdToResourcePath[currentId] = path;
                }
            }
            else if (line.StartsWith("tunnelIndex:"))
            {
                int.TryParse(line.Replace("tunnelIndex:", "").Trim(), out currentTunnelIndex);
            }
            else if (line.StartsWith("tunnelDirection:"))
            {
                // tunnelDirection: 0=Up, 1=Down, 2=Left, 3=Right, 4=None
                int dirVal = 4;
                int.TryParse(line.Replace("tunnelDirection:", "").Trim(), out dirVal);
                if (dirVal == 0) currentTunnelDir = Vector2Int.up;
                else if (dirVal == 1) currentTunnelDir = Vector2Int.down;
                else if (dirVal == 2) currentTunnelDir = Vector2Int.left;
                else if (dirVal == 3) currentTunnelDir = Vector2Int.right;
                else currentTunnelDir = Vector2Int.zero;
            }

            // Nếu kết thúc một block entry, reset temporary vars
            if (line == "-" || i == lines.Length - 1)
            {
                currentId = -1;
                currentTunnelIndex = -1;
                currentTunnelDir = Vector2Int.zero;
            }
        }

        Debug.Log($"Đã tự động nạp thành công {tiledIdToResourcePath.Count} ánh xạ loại gạch từ Database.");
    }

    // 2. Load và tạo Level từ JSON
    private void LoadLevel()
    {
        selectedLevelIndex = Array.IndexOf(availableLevelNames, levelMapName);
        currentLevelData = GetLevelDataAt(selectedLevelIndex);

        TextAsset mapText = Resources.Load<TextAsset>("levelmaps/" + levelMapName);
        if (mapText == null)
        {
            Debug.LogError("Không tìm thấy file level map JSON: Resources/levelmaps/" + levelMapName);
            return;
        }

        TiledMap parsedMap = JsonUtility.FromJson<TiledMap>(mapText.text);
        if (parsedMap == null || parsedMap.layers == null)
        {
            Debug.LogError("Lỗi parse map JSON.");
            return;
        }

        StopAllCoroutines();
        ClearCurrentLevel();
        activeMap = parsedMap;

        tilesetFirstGid = activeMap.tilesets != null && activeMap.tilesets.Count > 0
            ? Mathf.Max(1, activeMap.tilesets[0].firstgid)
            : 1;

        // Chuẩn bị shader unlit nếu chưa có
        if (unlitShader == null)
        {
            unlitShader = Shader.Find("Universal Render Pipeline/Unlit");
            if (unlitShader == null) unlitShader = Shader.Find("Unlit/Color");
            if (unlitShader == null) unlitShader = Shader.Find("Standard");
        }

        // Tạo container cha để gọn Hierarchy
        boardContainer = new GameObject("GameBoard");

        // Xây dựng danh sách loại fruit theo wave 1 từ respawnSequence
        wave1SpawnKinds = BuildWave1SpawnKinds();
        wave1SpawnKindIndex = 0;

        // Tìm spawn layer đầu tiên: ưu tiên "spawn1", nếu không có thì "spawn"
        TiledLayer spawnLayer = GetFirstSpawnLayer();

        // Dựng bản đồ từ tất cả layer tile gameplay, gồm map + ldf/obstacle layers.
        // Skip TẤT CẢ spawn layers (spawn, spawn1, spawn2, ...)
        foreach (TiledLayer mapLayer in activeMap.layers)
        {
            if (mapLayer == null || mapLayer.data == null)
                continue;
            if (IsSpawnLayer(mapLayer.name))
                continue;

            for (int y = 0; y < activeMap.height; y++)
            {
                for (int x = 0; x < activeMap.width; x++)
                {
                    int index = y * activeMap.width + x;
                    int gid = ResolveTiledId(mapLayer.data[index]);
                    Vector2Int gridPos = new Vector2Int(x, -y);

                    if (gid > 0)
                    {
                        gridMap[gridPos] = gid;
                        InstantiateTileVisual(gid, gridPos, boardContainer.transform);

                        // Đăng ký hầm chui nếu có
                        RegisterTunnelIfAny(gid, gridPos);
                    }
                }
            }
        }

        // Dựng đối tượng spawn (spawn layer: player start, pills)
        if (spawnLayer != null && spawnLayer.data != null)
        {
            for (int y = 0; y < activeMap.height; y++)
            {
                for (int x = 0; x < activeMap.width; x++)
                {
                    int index = y * activeMap.width + x;
                    int gid = ResolveTiledId(spawnLayer.data[index]);
                    Vector2Int gridPos = new Vector2Int(x, -y);

                    if (gid > 0)
                    {
                        spawnMap[gridPos] = gid;
                        ProcessSpawnObject(gid, gridPos);
                    }
                }
            }
        }

        // Khởi tạo lịch sử vị trí rắn chỉ khi có snake (không bắt buộc để fruit spawn)
        if (snakeHead != null)
        {
            snakePositionsHistory.Add(snakeGridPos);
            UpdateTailVisuals();
        }
        FitCameraToLevel();
        selectedLevelIndex = Array.IndexOf(availableLevelNames, levelMapName);
        currentLevelData = GetLevelDataAt(selectedLevelIndex);
        levelInput = levelMapName;
    }

    private void ClearCurrentLevel()
    {
        isMoving = false;
        moveDir = Vector2Int.zero;
        activeMap = null;
        gridMap.Clear();
        spawnMap.Clear();
        tunnelPairs.Clear();
        tunnelExitDirections.Clear();
        snakePositionsHistory.Clear();
        wave1SpawnKinds.Clear();
        wave1SpawnKindIndex = 0;

        foreach (GameObject pill in spawnedPills.Values)
        {
            if (pill != null)
            {
                Destroy(pill);
            }
        }
        spawnedPills.Clear();

        foreach (GameObject segment in tailSegments)
        {
            if (segment != null)
            {
                Destroy(segment);
            }
        }
        tailSegments.Clear();

        requiredTailLength = 3;

        if (snakeHead != null)
        {
            Destroy(snakeHead);
            snakeHead = null;
        }

        if (boardContainer != null)
        {
            Destroy(boardContainer);
            boardContainer = null;
        }

        if (backgroundContainer != null)
        {
            // Không destroy nếu đó là object được gán sẵn trong scene
            if (backgroundOverride != null && backgroundContainer == backgroundOverride.gameObject)
            {
                backgroundContainer = null; // chỉ unlink, không destroy
            }
            else
            {
                Destroy(backgroundContainer);
                backgroundContainer = null;
            }
        }

        // Dọn materials fruit đã tạo lúc runtime
        foreach (Material mat in runtimeFruitMats)
        {
            if (mat != null) Destroy(mat);
        }
        runtimeFruitMats.Clear();
    }

    /// <summary>
    /// Kiểm tra xem tên layer có phải là spawn layer không (spawn, spawn1, spawn2, ...).
    /// </summary>
    private static bool IsSpawnLayer(string layerName)
    {
        if (string.IsNullOrEmpty(layerName)) return false;
        return layerName.Equals("spawn", StringComparison.OrdinalIgnoreCase)
            || (layerName.StartsWith("spawn", StringComparison.OrdinalIgnoreCase)
                && layerName.Length > 5
                && char.IsDigit(layerName[5]));
    }

    /// <summary>
    /// Tìm spawn layer đầu tiên để xử lý wave 1:
    /// Ưu tiên "spawn1" > "spawn" > "spawn2" > ...
    /// Lý do: Level cũ dùng "spawn", level mới dùng "spawn1", "spawn2", ...
    /// Wave đầu tiên luôn là "spawn" hoặc "spawn1".
    /// </summary>
    private TiledLayer GetFirstSpawnLayer()
    {
        if (activeMap?.layers == null) return null;

        TiledLayer spawnExact = null;   // "spawn"
        TiledLayer spawn1 = null;       // "spawn1"

        foreach (TiledLayer layer in activeMap.layers)
        {
            if (layer == null || layer.data == null) continue;
            string name = layer.name ?? string.Empty;

            if (name.Equals("spawn", StringComparison.OrdinalIgnoreCase))
                spawnExact = layer;
            else if (name.Equals("spawn1", StringComparison.OrdinalIgnoreCase))
                spawn1 = layer;
        }

        // "spawn1" ưu tiên hơn "spawn" vì level mới dùng numbered scheme
        return spawn1 ?? spawnExact;
    }

    private int ResolveTiledId(int rawGid)
    {
        if (rawGid <= 0)
        {
            return 0;
        }

        // Tiled stores global IDs. TileDefinitionDatabase stores local tiledId values.
        return rawGid - tilesetFirstGid;
    }


    private void InstantiateTileVisual(int gid, Vector2Int gridPos, Transform parent)
    {
        if (tiledIdToResourcePath.TryGetValue(gid, out string resPath))
        {
            GameObject tilePrefab = Resources.Load<GameObject>(resPath);
            if (tilePrefab != null)
            {
                Vector3 worldPos = new Vector3(gridPos.x, gridPos.y, 0f);
                GameObject spawnedTile = Instantiate(tilePrefab, worldPos, Quaternion.identity, parent);
                spawnedTile.name = $"Tile_{gridPos.x}_{Mathf.Abs(gridPos.y)}_{tilePrefab.name}";
                
                // Reset Z rotation nếu hầm chui để hướng đúng
                AdjustTunnelRotation(gid, spawnedTile);
            }
        }
    }

    private void FitCameraToLevel()
    {
        if (activeMap == null)
        {
            return;
        }

        Camera cam = targetCamera != null ? targetCamera : Camera.main;
        if (cam == null)
        {
            Debug.LogWarning("Sandbox camera fit skipped because no camera is assigned and no MainCamera exists.");
            return;
        }

        targetCamera = cam;

        float width = Mathf.Max(1, activeMap.width);
        float height = Mathf.Max(1, activeMap.height);
        Vector3 center = new Vector3((width - 1f) * 0.5f, -(height - 1f) * 0.5f, 0f);
        float aspect = Mathf.Max(0.01f, cam.aspect);
        float verticalSize = (height * 0.5f) + cameraPadding;
        float horizontalSize = ((width * 0.5f) + cameraPadding) / aspect;

        cam.orthographic = true;
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = gameBackgroundColor;
        cam.orthographicSize = Mathf.Max(verticalSize, horizontalSize);
        cam.transform.position = new Vector3(center.x, center.y, -10f);
        cam.transform.rotation = Quaternion.identity;

        UpdateBackground(center, width, height);
    }

    private void UpdateBackground(Vector3 center, float width, float height)
    {
        if (!showGameBackground)
        {
            if (backgroundContainer != null && backgroundContainer != (backgroundOverride != null ? backgroundOverride.gameObject : null))
                backgroundContainer.SetActive(false);
            return;
        }

        // Nếu người dùng gán sẵn background trong scene, dùng nó thay vì tạo mới
        if (backgroundOverride != null)
        {
            backgroundContainer = backgroundOverride.gameObject;
            backgroundContainer.SetActive(true);
        }
        else if (backgroundContainer == null)
        {
            backgroundContainer = GameObject.CreatePrimitive(PrimitiveType.Quad);
            backgroundContainer.name = "Ground_BG";
            Collider col = backgroundContainer.GetComponent<Collider>();
            if (col != null) Destroy(col);
        }

        // Rotation: Quad phải nằm NGANG (-90° trục X) để shader SH_Tile_FakeUnlit
        // phát hiện đúng "top face" qua world-space normal hướng Y+ (giống Game scene)
        // Position: center XY của map, z từ backgroundOverride.transform.position.z nếu có
        float bgZ = backgroundOverride != null
            ? backgroundOverride.transform.position.z
            : 0.1f;
        backgroundContainer.transform.position = new Vector3(center.x, center.y, bgZ);

        if (backgroundOverride != null)
        {
            // Giữ nguyên rotation đã set trong scene (Inspector)
            // Scale: vì Quad nằm ngang (-90° X), truc X = East/West, truc Z = North/South
            // Dùng XZ scale: localScale.x = width, localScale.z = height
            backgroundContainer.transform.localScale = new Vector3(
                width + backgroundMargin * 2f,
                backgroundContainer.transform.localScale.y,
                height + backgroundMargin * 2f
            );
        }
        else
        {
            // Quad mới tạo: set rotation -90° X rồi scale XZ
            backgroundContainer.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            backgroundContainer.transform.localScale = new Vector3(
                width + backgroundMargin * 2f,
                1f,
                height + backgroundMargin * 2f
            );
        }

        MeshRenderer renderer = backgroundOverride != null
            ? backgroundOverride
            : backgroundContainer.GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            // Nếu đang dùng backgroundOverride, chỉ cập nhật scale/position, không ghi đè material
            if (backgroundOverride == null)
            {
                renderer.sharedMaterial = GetBackgroundMaterial(width, height);
            }
            else
            {
                // Vẫn scale texture nếu material có property
                if (renderer.sharedMaterial != null)
                    SetBackgroundTextureScale(width, height);
            }
        }
    }

    private Material GetBackgroundMaterial(float width, float height)
    {
        if (backgroundMaterial != null)
        {
            SetBackgroundTextureScale(width, height);
            return backgroundMaterial;
        }

        Shader shader = Shader.Find("Universal Render Pipeline/Unlit");
        if (shader == null)
        {
            shader = Shader.Find("Unlit/Texture");
        }
        if (shader == null)
        {
            shader = Shader.Find("Sprites/Default");
        }

        backgroundMaterial = new Material(shader);
        backgroundMaterial.name = "Sandbox_Ground_BG_Runtime";
        SetMaterialColor(backgroundMaterial, grassBackgroundColor);

#if UNITY_EDITOR
        Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Texture2D/Platform_Grass.png");
        if (texture != null)
        {
            texture.wrapMode = TextureWrapMode.Repeat;
            SetMaterialTexture(backgroundMaterial, texture);
        }
#endif

        SetBackgroundTextureScale(width, height);
        return backgroundMaterial;
    }

    private void SetBackgroundTextureScale(float width, float height)
    {
        if (backgroundMaterial == null)
        {
            return;
        }

        Vector2 scale = new Vector2((width + backgroundMargin * 2f) / 2.56f, (height + backgroundMargin * 2f) / 2.56f);
        if (backgroundMaterial.HasProperty("_BaseMap")) backgroundMaterial.SetTextureScale("_BaseMap", scale);
        if (backgroundMaterial.HasProperty("_MainTex")) backgroundMaterial.SetTextureScale("_MainTex", scale);
    }

    private static void SetMaterialColor(Material mat, Color color)
    {
        if (mat == null)
        {
            return;
        }

        if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", color);
        if (mat.HasProperty("_Color")) mat.SetColor("_Color", color);
    }

    private static void SetMaterialTexture(Material mat, Texture texture)
    {
        if (mat == null || texture == null)
        {
            return;
        }

        if (mat.HasProperty("_BaseMap")) mat.SetTexture("_BaseMap", texture);
        if (mat.HasProperty("_MainTex")) mat.SetTexture("_MainTex", texture);
    }

    private void HandleSandboxShortcuts()
    {
        if (Input.GetKeyDown(KeyCode.PageUp) || Input.GetKeyDown(KeyCode.LeftBracket))
        {
            LoadAdjacentLevel(-1);
        }
        else if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.RightBracket))
        {
            LoadAdjacentLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            FitCameraToLevel();
        }
    }

    private void LoadAdjacentLevel(int delta)
    {
        if (availableLevelNames == null || availableLevelNames.Length == 0)
        {
            return;
        }

        int currentIndex = selectedLevelIndex >= 0
            ? selectedLevelIndex
            : Array.IndexOf(availableLevelNames, levelMapName);

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }

        int nextIndex = Mathf.Clamp(currentIndex + delta, 0, availableLevelNames.Length - 1);
        if (nextIndex == currentIndex)
        {
            return;
        }

        levelMapName = availableLevelNames[nextIndex];
        LoadLevel();
    }

    private void OnGUI()
    {
        if (!showLevelSwitcher)
        {
            return;
        }

        float panelHeight = showLevelInfo ? 318f : 182f;
        GUILayout.BeginArea(new Rect(12f, 12f, 360f, panelHeight), GUI.skin.box);
        GUILayout.Label("Sandbox Level");

        // --- Cohort switcher ---
        GUILayout.BeginHorizontal();
        GUI.enabled = allCohorts != null && allCohorts.Length > 1 && activeCohortIndex > 0;
        if (GUILayout.Button("◄", GUILayout.Width(28f)))
            SwitchCohort(-1);
        GUI.enabled = true;

        string cohortDisplay = activeCohort != null
            ? $"{activeCohort.cohortName}  [{activeCohortIndex + 1}/{(allCohorts != null ? allCohorts.Length : 1)}]"
            : "levelmaps";
        GUILayout.Label(cohortDisplay);

        GUI.enabled = allCohorts != null && allCohorts.Length > 1 && activeCohortIndex < allCohorts.Length - 1;
        if (GUILayout.Button("►", GUILayout.Width(28f)))
            SwitchCohort(1);
        GUI.enabled = true;
        GUILayout.EndHorizontal();

        // --- Level switcher ---
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Prev", GUILayout.Width(70f)))
        {
            LoadAdjacentLevel(-1);
        }
        if (GUILayout.Button("Next", GUILayout.Width(70f)))
        {
            LoadAdjacentLevel(1);
        }
        if (GUILayout.Button("Reload", GUILayout.Width(80f)))
        {
            LoadLevel();
        }
        if (GUILayout.Button("Fit", GUILayout.Width(60f)))
        {
            FitCameraToLevel();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Map", GUILayout.Width(38f));
        levelInput = GUILayout.TextField(levelInput ?? string.Empty, GUILayout.Width(190f));
        if (GUILayout.Button("Load", GUILayout.Width(70f)))
        {
            string trimmedInput = levelInput != null ? levelInput.Trim() : string.Empty;
            if (!string.IsNullOrEmpty(trimmedInput))
            {
                levelMapName = trimmedInput;
                LoadLevel();
            }
        }
        GUILayout.EndHorizontal();

        string indexText = selectedLevelIndex >= 0 && availableLevelNames.Length > 0
            ? $"{selectedLevelIndex + 1}/{availableLevelNames.Length}"
            : "-";
        GUILayout.Label($"{FormatLevelLabel(currentLevelData)} ({indexText})");

        if (showLevelInfo && currentLevelData != null)
        {
            GUILayout.Space(4);
            GUILayout.Label("Level Data");
            InfoRow("Crates", currentLevelData.cratesTotal.ToString());
            InfoRow("Difficulty", currentLevelData.difficulty.ToString());
            InfoRow("Diff Score", currentLevelData.difficultyScore.ToString());
            InfoRow("Speed", currentLevelData.speedPlayer.ToString("F1"));
            InfoRow("Rising Block", currentLevelData.risingBlockDeliveriesToLower.ToString());
            InfoRow("Wall HP", currentLevelData.destructibleWallHealth.ToString());
            InfoRow("Seed Random", currentLevelData.usingSeedRandom ? currentLevelData.seedRandom.ToString() : "Off");
        }

        GUILayout.EndArea();
    }

    private LevelDataSO GetLevelDataAt(int index)
    {
        if (availableLevelData == null || index < 0 || index >= availableLevelData.Length)
        {
            return null;
        }

        return availableLevelData[index];
    }

    private string FormatLevelLabel(LevelDataSO level)
    {
        int levelNumber = selectedLevelIndex >= 0 ? selectedLevelIndex + 1 : 0;
        if (level != null)
        {
            return $"Lv {levelNumber:000}  {level.name}";
        }

        return levelNumber > 0 ? $"Lv {levelNumber:000}  {levelMapName}" : levelMapName;
    }

    private void InfoRow(string label, string value)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label + ":", GUILayout.Width(96f));
        GUILayout.Label(value);
        GUILayout.EndHorizontal();
    }

    private static int CompareLevelNames(string a, string b)
    {
        ParseLevelName(a, out int numberA, out int versionA);
        ParseLevelName(b, out int numberB, out int versionB);

        int numberCompare = numberA.CompareTo(numberB);
        if (numberCompare != 0)
        {
            return numberCompare;
        }

        int versionCompare = versionA.CompareTo(versionB);
        return versionCompare != 0 ? versionCompare : string.CompareOrdinal(a, b);
    }

    private static void ParseLevelName(string value, out int number, out int version)
    {
        number = int.MaxValue;
        version = int.MaxValue;

        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        string[] parts = value.Split(new[] { "_v" }, StringSplitOptions.None);
        if (!int.TryParse(parts[0], out number))
        {
            number = int.MaxValue;
        }

        if (parts.Length > 1)
        {
            if (!int.TryParse(parts[1], out version))
            {
                version = int.MaxValue;
            }
        }
    }

    private void AdjustTunnelRotation(int gid, GameObject spawnedTile)
    {
        // 278: Left, 279: Up, 280: Right, 281: Down
        if (gid == 278) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (gid == 279) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (gid == 280) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (gid == 281) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        // Tunnel B (361: Left, 363: Up, 362: Right, 360: Down)
        else if (gid == 361) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (gid == 363) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (gid == 362) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (gid == 360) spawnedTile.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void RegisterTunnelIfAny(int gid, Vector2Int gridPos)
    {
        // Tunnels:
        // Tunnel Index 0 (GID 278, 279, 280, 281)
        // Tunnel Index 1 (GID 360, 361, 362, 363)
        // Tunnel Index 2 (GID 384, 385, 386, 382)
        // Tunnel Index 3 (GID 380, 381, 379, 378)
        int tunnelIndex = -1;
        Vector2Int exitDir = Vector2Int.zero;

        if (gid == 278) { tunnelIndex = 0; exitDir = Vector2Int.left; }
        else if (gid == 279) { tunnelIndex = 0; exitDir = Vector2Int.up; }
        else if (gid == 280) { tunnelIndex = 0; exitDir = Vector2Int.right; }
        else if (gid == 281) { tunnelIndex = 0; exitDir = Vector2Int.down; }

        else if (gid == 361) { tunnelIndex = 1; exitDir = Vector2Int.left; }
        else if (gid == 363) { tunnelIndex = 1; exitDir = Vector2Int.up; }
        else if (gid == 362) { tunnelIndex = 1; exitDir = Vector2Int.right; }
        else if (gid == 360) { tunnelIndex = 1; exitDir = Vector2Int.down; }

        else if (gid == 385) { tunnelIndex = 2; exitDir = Vector2Int.left; }
        else if (gid == 382) { tunnelIndex = 2; exitDir = Vector2Int.up; }
        else if (gid == 386) { tunnelIndex = 2; exitDir = Vector2Int.right; }
        else if (gid == 384) { tunnelIndex = 2; exitDir = Vector2Int.down; }

        else if (gid == 379) { tunnelIndex = 3; exitDir = Vector2Int.left; }
        else if (gid == 378) { tunnelIndex = 3; exitDir = Vector2Int.up; }
        else if (gid == 381) { tunnelIndex = 3; exitDir = Vector2Int.right; }
        else if (gid == 380) { tunnelIndex = 3; exitDir = Vector2Int.down; }

        if (tunnelIndex != -1)
        {
            if (!tunnelPairs.ContainsKey(tunnelIndex))
            {
                tunnelPairs[tunnelIndex] = new List<Vector2Int>();
            }
            tunnelPairs[tunnelIndex].Add(gridPos);
            tunnelExitDirections[gridPos] = exitDir;
        }
    }

    private void ProcessSpawnObject(int gid, Vector2Int gridPos)
    {
        Vector3 worldPos = new Vector3(gridPos.x, gridPos.y, 0f);
        
        // 287 = player_start_position
        if (gid == 287)
        {
            if (snakeHeadPrefab != null)
            {
                snakeHead = Instantiate(snakeHeadPrefab, worldPos, Quaternion.identity);
                snakeHead.name = "SnakeHead";
            }
            else
            {
                // Fallback nếu không gán prefab
                snakeHead = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                snakeHead.transform.position = worldPos;
                snakeHead.name = "SnakeHead_Fallback";
            }
            snakeGridPos = gridPos;
            targetGridPos = gridPos;
        }
        // 277 = pill_spawn_point, 276 = not_pills_spawn_tile (vẫn spawn fruit từ wave data)
        // 371-377 = spawn theo loại fruit cụ thể trong spawn layer
        else if (gid == 277 || gid == 276 || (gid >= 371 && gid <= 377))
        {
            SpawnFruitAtCell(gid, gridPos, worldPos);
        }
    }

    /// <summary>
    /// Xây dựng danh sách PillKind theo thứ tự từ wave 1 (batches[0]) trong respawnSequence.
    /// Giống logic BuildSpawnKindSequence trong LevelViewer3DManager.
    /// </summary>
    private List<PillKind> BuildWave1SpawnKinds()
    {
        var result = new List<PillKind>();
        if (currentLevelData == null) return result;

        var batches = currentLevelData.respawnSequence?.batches;
        if (batches == null || batches.Count == 0) return result;

        var colors = batches[0]?.colors;
        if (colors == null) return result;

        foreach (var colorEntry in colors)
        {
            if (colorEntry == null) continue;
            int count = Mathf.Max(0, colorEntry.count);
            for (int i = 0; i < count; i++)
                result.Add(colorEntry.pillKind);
        }

        return result;
    }

    /// <summary>
    /// Spawn fruit visual đúng loại tại một ô, sử dụng PillMaster prefab hoặc fallback sphere có màu.
    /// Nếu có wave1SpawnKinds thì lấy theo thứ tự round-robin, ngược lại dùng GID để suy loại.
    /// </summary>
    private void SpawnFruitAtCell(int gid, Vector2Int gridPos, Vector3 worldPos)
    {
        // Xác định loại fruit
        PillKind kind;
        if (wave1SpawnKinds.Count > 0)
        {
            kind = wave1SpawnKinds[wave1SpawnKindIndex % wave1SpawnKinds.Count];
            wave1SpawnKindIndex++;
        }
        else if (gid >= 371 && gid <= 377)
        {
            kind = (PillKind)(gid - 371);
        }
        else
        {
            kind = PillKind.Strawberry; // fallback
        }

        GameObject pill = null;

        // Thử dùng pillPrefab được gán trong Inspector (PillMaster)
        if (pillPrefab != null)
        {
            pill = Instantiate(pillPrefab, worldPos, Quaternion.identity);
            pill.name = $"Pill_{kind}_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
            ActivatePillKindOnInstance(pill, kind);
        }
        else
        {
            // Fallback: sphere có màu theo loại fruit
            pill = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pill.name = $"Pill_{kind}_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
            pill.transform.position = worldPos;
            pill.transform.localScale = Vector3.one * 0.45f;

            Collider col = pill.GetComponent<Collider>();
            if (col != null) Destroy(col);

            MeshRenderer mr = pill.GetComponent<MeshRenderer>();
            if (mr != null && unlitShader != null)
            {
                Material mat = new Material(unlitShader);
                mat.name = $"FruitMat_{kind}";
                Color c = GetPillColor(kind);
                if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", c);
                if (mat.HasProperty("_Color")) mat.SetColor("_Color", c);
                mr.sharedMaterial = mat;
                runtimeFruitMats.Add(mat);
            }
        }

        if (pill != null)
        {
            spawnedPills[gridPos] = pill;
        }
    }

    /// <summary>
    /// Kích hoạt đúng child PillColorShape tương ứng với loại fruit.
    /// Port từ LevelViewer3DManager.ActivatePillKind.
    /// </summary>
    private static void ActivatePillKindOnInstance(GameObject instance, PillKind kind)
    {
        PillColorShape[] shapes = instance.GetComponentsInChildren<PillColorShape>(true);

        foreach (PillColorShape shape in shapes)
            shape.gameObject.SetActive(false);

        foreach (Transform child in instance.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == "Calibrators" || child.name == "SecreteCollectibleParent")
                child.gameObject.SetActive(false);
        }

        foreach (PillColorShape shape in shapes)
        {
            if (shape.pillKind != kind) continue;
            shape.gameObject.SetActive(true);
            ActivateParentsUntil(shape.transform, instance.transform);
        }
    }

    private static void ActivateParentsUntil(Transform child, Transform root)
    {
        Transform current = child.parent;
        while (current != null && current != root.parent)
        {
            current.gameObject.SetActive(true);
            if (current == root) break;
            current = current.parent;
        }
    }

    private static Color GetPillColor(PillKind kind)
    {
        switch (kind)
        {
            case PillKind.Strawberry: return new Color(0.95f, 0.12f, 0.24f, 1f);
            case PillKind.Blueberry:  return new Color(0.17f, 0.32f, 0.85f, 1f);
            case PillKind.Banana:     return new Color(0.98f, 0.78f, 0.18f, 1f);
            case PillKind.Pear:       return new Color(0.74f, 0.90f, 0.27f, 1f);
            case PillKind.Apple:      return new Color(0.35f, 0.78f, 0.20f, 1f);
            case PillKind.Carrot:     return new Color(0.98f, 0.45f, 0.08f, 1f);
            case PillKind.Eggplant:   return new Color(0.55f, 0.18f, 0.82f, 1f);
            default:                   return Color.white;
        }
    }

    // 3. Nhận diện điều khiển vuốt (Swipe) & Bàn phím (WASD / Mũi tên)
    private void HandleInput()
    {
        if (isMoving) return;

        // Bàn phím PC
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) TrySwipe(Vector2Int.up);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) TrySwipe(Vector2Int.down);
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) TrySwipe(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) TrySwipe(Vector2Int.right);

        // Chuột & Cảm ứng vuốt (Swipe)
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            isSwipeDetected = true;
        }
        else if (Input.GetMouseButtonUp(0) && isSwipeDetected)
        {
            Vector2 dragVector = (Vector2)Input.mousePosition - touchStartPos;
            if (dragVector.magnitude > 40f) // Threshold vuốt tối thiểu
            {
                dragVector.Normalize();
                if (Mathf.Abs(dragVector.x) > Mathf.Abs(dragVector.y))
                {
                    if (dragVector.x > 0) TrySwipe(Vector2Int.right);
                    else TrySwipe(Vector2Int.left);
                }
                else
                {
                    if (dragVector.y > 0) TrySwipe(Vector2Int.up);
                    else TrySwipe(Vector2Int.down);
                }
            }
            isSwipeDetected = false;
        }
    }

    private void TrySwipe(Vector2Int dir)
    {
        if (isMoving) return;

        // Không cho phép đi ngược hướng đuôi ngay lập tức nếu đang có đuôi
        if (tailSegments.Count > 0 && snakePositionsHistory.Count > 1)
        {
            Vector2Int lastPos = snakePositionsHistory[snakePositionsHistory.Count - 2];
            if (snakeGridPos + dir == lastPos)
            {
                return; // Bị chặn vì là hướng đuôi
            }
        }

        moveDir = dir;
        StartCoroutine(SlideToObstacle());
    }

    // 4. Thuật toán di chuyển trượt thẳng của rắn
    private IEnumerator SlideToObstacle()
    {
        isMoving = true;

        while (true)
        {
            Vector2Int nextPos = snakeGridPos + moveDir;

            // Kiểm tra va chạm: Đụng tường, đụng đuôi hoặc ngoài bản đồ
            if (IsObstacle(nextPos))
            {
                // Kiểm tra xem vị trí hiện tại có phải là hầm chui (tunnel) không
                if (TryTriggerTunnel(snakeGridPos, out Vector2Int exitCell, out Vector2Int exitDirection))
                {
                    // Thực hiện di chuyển teleport qua hầm chui
                    yield return TeleportThroughTunnel(exitCell, exitDirection);
                    continue; // Tiếp tục trượt từ điểm ra hầm chui
                }

                break; // Dừng lại vì đụng chướng ngại vật thực sự
            }

            // Thực hiện di chuyển sang ô tiếp theo
            targetGridPos = nextPos;
            Vector3 startPos = snakeHead.transform.position;
            Vector3 endPos = new Vector3(targetGridPos.x, targetGridPos.y, 0f);
            
            // Xoay đầu rắn theo hướng di chuyển
            RotateHead(moveDir);

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                snakeHead.transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }

            snakeHead.transform.position = endPos;
            snakeGridPos = targetGridPos;

            // Ghi nhận lịch sử vị trí cho hệ thống Đuôi
            snakePositionsHistory.Add(snakeGridPos);

            // Kiểm tra ăn Pills
            CheckEatingPill(snakeGridPos);

            // Cập nhật vị trí các khớp Đuôi
            UpdateTailVisuals();
        }

        isMoving = false;
    }

    // 5. Kiểm tra va chạm (Obstacle Checks)
    private bool IsObstacle(Vector2Int pos)
    {
        // Kiểm tra ngoài bản đồ
        if (pos.x < 0 || pos.x >= activeMap.width || -pos.y < 0 || -pos.y >= activeMap.height)
        {
            return true;
        }

        // Kiểm tra xem ô tiếp theo có gạch nền hợp lệ không (có nằm trong gridMap)
        if (!gridMap.ContainsKey(pos))
        {
            return true; // Không có đường đi -> coi như tường
        }

        int gid = gridMap[pos];

        // 322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 333, 334, 335, 336, 337, 342, 343, 344, 345
        // Tất cả các GID trên đại diện cho cỏ/chướng ngại vật (IsGrass / Border / Wall)
        if (IsGrassOrWall(gid))
        {
            return true; // Đụng tường cỏ
        }

        // Kiểm tra va chạm với đuôi rắn hiện tại
        int tailCountToCheck = Mathf.Min(tailSegments.Count, snakePositionsHistory.Count - 1);
        for (int i = 0; i < tailCountToCheck; i++)
        {
            Vector2Int tailCell = snakePositionsHistory[snakePositionsHistory.Count - 2 - i];
            if (pos == tailCell)
            {
                // Kiểm tra nếu ô tiếp theo trùng khớp với Đuôi nhưng là Cầu Vượt (Bridges)
                // Cầu vượt dọc (GID 357), Cầu vượt ngang (GID 359)
                if (IsOnBridge(pos, out bool isBridgeLR))
                {
                    // Nếu rắn đang đi vuông góc với cầu, cho phép đi qua
                    if (isBridgeLR && (moveDir == Vector2Int.up || moveDir == Vector2Int.down))
                    {
                        continue; // Đi qua cầu chui dọc bên dưới đường ngang
                    }
                    if (!isBridgeLR && (moveDir == Vector2Int.left || moveDir == Vector2Int.right))
                    {
                        continue; // Đi qua cầu vượt ngang bên trên đường dọc
                    }
                }

                Debug.LogWarning("Ouch! Rắn tự đụng vào đuôi của mình!");
                return true; // Va chạm với đuôi
            }
        }

        return false;
    }

    private bool IsGrassOrWall(int gid)
    {
        // GID cỏ, biên cỏ, đảo cỏ
        if (gid >= 322 && gid <= 345) return true;
        
        // 294 = Stop tile (vật cản chặn đường)
        if (gid == 294) return true;

        return false;
    }

    private bool IsOnBridge(Vector2Int pos, out bool isBridgeLR)
    {
        isBridgeLR = false;
        if (gridMap.TryGetValue(pos, out int gid))
        {
            if (gid == 359) // LR Bridge
            {
                isBridgeLR = true;
                return true;
            }
            if (gid == 357) // UD Bridge
            {
                isBridgeLR = false;
                return true;
            }
        }
        return false;
    }

    // 6. Hệ thống Hầm chui (Tunnels)
    private bool TryTriggerTunnel(Vector2Int cell, out Vector2Int exitCell, out Vector2Int exitDirection)
    {
        exitCell = cell;
        exitDirection = Vector2Int.zero;

        // Tìm xem ô hiện tại có phải là hầm chui đăng ký không
        foreach (var pair in tunnelPairs)
        {
            if (pair.Value.Contains(cell) && pair.Value.Count == 2)
            {
                // Lấy ô hầm chui còn lại làm lối ra
                exitCell = pair.Value[0] == cell ? pair.Value[1] : pair.Value[0];
                exitDirection = tunnelExitDirections[exitCell];
                return true;
            }
        }
        return false;
    }

    private IEnumerator TeleportThroughTunnel(Vector2Int exitCell, Vector2Int exitDirection)
    {
        // 1. Co rút rắn đi vào hầm
        Vector3 enterPos = snakeHead.transform.position;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed * 1.5f;
            snakeHead.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }

        // 2. Di chuyển đầu rắn sang vị trí hầm ra
        snakeHead.transform.position = new Vector3(exitCell.x, exitCell.y, 0f);
        snakeGridPos = exitCell;
        targetGridPos = exitCell;
        moveDir = exitDirection; // Ép buộc rắn di chuyển theo hướng thoát của hầm chui
        RotateHead(moveDir);

        // 3. Phình rắn to lại tại lối ra
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed * 1.5f;
            snakeHead.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        snakeHead.transform.localScale = Vector3.one;

        // Ghi nhận vị trí hầm chui vào lịch sử di chuyển
        snakePositionsHistory.Add(snakeGridPos);
        UpdateTailVisuals();
    }

    // 7. Ăn Pills (Eating & Score Progression)
    private void CheckEatingPill(Vector2Int pos)
    {
        if (spawnedPills.TryGetValue(pos, out GameObject pill))
        {
            // 1. Ăn pill
            Destroy(pill);
            spawnedPills.Remove(pos);
            
            // 2. Tăng chiều dài đuôi rắn
            requiredTailLength++;
            Debug.Log($"Măm măm! Đã ăn kẹo tại {pos}. Độ dài đuôi hiện tại: {requiredTailLength}");

            // 3. Kiểm tra điều kiện thắng màn
            if (spawnedPills.Count == 0)
            {
                Debug.Log("CHÚC MỪNG! BẠN ĐÃ ĂN HẾT TOÀN BỘ KẸO VÀ CHIẾN THẮNG MÀN CHƠI!");
            }
        }
    }

    // 8. Thuật toán di chuyển & Cập nhật khớp Đuôi (Tail Follower)
    private void UpdateTailVisuals()
    {
        if (snakeHead == null)
        {
            return;
        }

        // Giới hạn chiều dài thực tế tối đa của đuôi theo lịch sử di chuyển
        int targetTailCount = Mathf.Min(requiredTailLength, snakePositionsHistory.Count - 1);

        // Spawning/Destroying khớp đuôi để khớp với độ dài yêu cầu
        while (tailSegments.Count < targetTailCount)
        {
            GameObject seg;
            if (snakeTailPrefab != null)
            {
                seg = Instantiate(snakeTailPrefab, snakeHead.transform.position, Quaternion.identity);
            }
            else
            {
                seg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                seg.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            tailSegments.Add(seg);
        }

        // Định vị vị trí từng khớp đuôi dọc theo lịch sử di chuyển (LIFO)
        for (int i = 0; i < tailSegments.Count; i++)
        {
            // Vị trí đuôi i sẽ tương ứng vị trí thứ `history.Count - 2 - i`
            int historyIndex = snakePositionsHistory.Count - 2 - i;
            if (historyIndex >= 0)
            {
                Vector2Int gridPos = snakePositionsHistory[historyIndex];
                Vector3 targetPos = new Vector3(gridPos.x, gridPos.y, 0f);
                
                // Di chuyển mượt mà đuôi
                tailSegments[i].transform.position = targetPos;

                // Xoay khớp đuôi theo khớp đứng trước nó
                Vector2Int frontPos = (i == 0) ? snakeGridPos : snakePositionsHistory[historyIndex + 1];
                Vector2Int dirToFront = frontPos - gridPos;
                RotateTailSegment(tailSegments[i], dirToFront);
            }
        }
    }

    // Tiện ích xoay khớp đầu rắn
    private void RotateHead(Vector2Int dir)
    {
        if (snakeHead == null)
        {
            return;
        }

        if (dir == Vector2Int.up) snakeHead.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (dir == Vector2Int.down) snakeHead.transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (dir == Vector2Int.left) snakeHead.transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (dir == Vector2Int.right) snakeHead.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Tiện ích xoay khớp đuôi rắn
    private void RotateTailSegment(GameObject seg, Vector2Int dirToFront)
    {
        if (dirToFront == Vector2Int.up) seg.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (dirToFront == Vector2Int.down) seg.transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (dirToFront == Vector2Int.left) seg.transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (dirToFront == Vector2Int.right) seg.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnDestroy()
    {
        if (backgroundMaterial != null)
        {
            Destroy(backgroundMaterial);
            backgroundMaterial = null;
        }

        foreach (Material mat in runtimeFruitMats)
        {
            if (mat != null) Destroy(mat);
        }
        runtimeFruitMats.Clear();
    }
}
