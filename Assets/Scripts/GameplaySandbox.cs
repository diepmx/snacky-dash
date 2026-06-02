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
    public enum InitialFruitPlacementMode
    {
        MarkerExpansion,
        SpreadAcrossPath
    }

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

    [Header("Game View Composition")]
    public bool usePerspectiveCamera = true;
    public bool useFixedPerspectiveCameraPose = true;
    public Vector3 fixedPerspectiveCameraPosition = new Vector3(7f, -43.5f, -71.42f);
    public Vector3 fixedPerspectiveCameraEuler = new Vector3(-26.5f, 0f, 0f);
    [Range(15f, 60f)]
    public float perspectiveFieldOfView = 26f;
    public float perspectiveDistanceMultiplier = 1.15f;
    public float perspectiveVerticalOffset = 0.45f;
    public Vector3 perspectiveLookOffset = new Vector3(0f, -0.35f, 0f);

    [Header("Crate Preview")]
    public bool showCratePreview = true;
    public GameObject nextCrateSignPrefab;
    public GameObject boxCrate9Prefab;
    public GameObject boxCrate18Prefab;
    public GameObject boxCrate27Prefab;
    public Vector2 cratePreviewOffset = new Vector2(-0.87f, 1.75f);
    public float nextCrateSignScale = 0.9f;
    public float boxCrateScale = 0.68f;
    public float cratePreviewSpacing = 1.75f;

    [Header("Fruit Presentation")]
    public bool useMeshFruitVisuals = false;
    public bool fillInitialWaveFromData = true;
    public int initialWaveFillMarkerThreshold = 10;
    public InitialFruitPlacementMode initialFruitPlacementMode = InitialFruitPlacementMode.SpreadAcrossPath;
    public Vector3 fruitTiltEuler = new Vector3(-14f, 0f, 0f);
    public float meshFruitScale = 0.36f;

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
    private GameObject cratePreviewContainer;

    // Cohort switching
    private LevelCohortSO[] allCohorts = new LevelCohortSO[0];
    private int activeCohortIndex = 0;

    // Fruit spawn - wave 1
    private List<PillKind> wave1SpawnKinds = new List<PillKind>();
    private int wave1SpawnKindIndex = 0;
    private readonly Dictionary<string, GameObject> prefabCache = new Dictionary<string, GameObject>();
    private readonly Dictionary<PillKind, Mesh> fruitMeshCache = new Dictionary<PillKind, Mesh>();
    private readonly Dictionary<PillKind, Material> fruitMaterialCache = new Dictionary<PillKind, Material>();
    private Shader unlitShader;
    private readonly List<Material> runtimeFruitMats = new List<Material>();

    private struct SpawnCellData
    {
        public int Gid;
        public Vector2Int GridPos;
    }

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
            selectedLevelIndex = FindLevelIndex(levelMapName);
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
        selectedLevelIndex = FindLevelIndex(levelMapName);
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
        selectedLevelIndex = FindLevelIndex(levelMapName);
        currentLevelData = GetLevelDataAt(selectedLevelIndex);

        TextAsset mapText = LoadLevelMapTextAsset(levelMapName);
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

        selectedLevelIndex = FindLevelIndex(levelMapName);
        currentLevelData = GetLevelDataAt(selectedLevelIndex);
        levelInput = levelMapName;

        // Xây dựng danh sách loại fruit theo wave 1 từ respawnSequence
        wave1SpawnKinds = BuildWave1SpawnKinds();
        wave1SpawnKindIndex = 0;

        // Tìm spawn layer đầu tiên: ưu tiên "spawn1", nếu không có thì "spawn"
        TiledLayer spawnLayer = GetFirstSpawnLayer();

        // Dựng bản đồ từ tất cả layer tile gameplay, gồm map + ldf/obstacle layers.
        // Skip TẤT CẢ spawn layers (spawn, spawn1, spawn2, ...)
        int visualLayerIndex = 0;
        foreach (TiledLayer mapLayer in activeMap.layers)
        {
            if (mapLayer == null || mapLayer.data == null)
                continue;
            if (IsSpawnLayer(mapLayer.name))
                continue;

            float layerZ = -visualLayerIndex * 0.01f;
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
                        InstantiateTileVisual(gid, gridPos, boardContainer.transform, layerZ);

                        // Đăng ký hầm chui nếu có
                        RegisterTunnelIfAny(gid, gridPos);
                    }
                }
            }

            visualLayerIndex++;
        }

        // Dựng đối tượng spawn (spawn layer: player start, pills)
        List<SpawnCellData> initialFruitSlots = new List<SpawnCellData>();
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
                        if (gid == 287)
                        {
                            ProcessSpawnObject(gid, gridPos);
                        }
                        else if (IsInitialFruitSpawnTile(gid))
                        {
                            initialFruitSlots.Add(new SpawnCellData { Gid = gid, GridPos = gridPos });
                        }
                    }
                }
            }
        }

        // Khởi tạo lịch sử vị trí rắn chỉ khi có snake (không bắt buộc để fruit spawn)
        SpawnInitialFruits(initialFruitSlots);

        if (snakeHead != null)
        {
            snakePositionsHistory.Add(snakeGridPos);
            UpdateTailVisuals();
        }
        SpawnCratePreview();
        FitCameraToLevel();
    }

    private TextAsset LoadLevelMapTextAsset(string mapName)
    {
        if (string.IsNullOrWhiteSpace(mapName))
        {
            return null;
        }

        TextAsset mapText = Resources.Load<TextAsset>("levelmaps/" + mapName.Trim());
        if (mapText != null)
        {
            return mapText;
        }

        string normalized = NormalizeLevelName(mapName);
        if (!string.Equals(normalized, mapName, StringComparison.Ordinal))
        {
            return Resources.Load<TextAsset>("levelmaps/" + normalized);
        }

        return null;
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

        if (cratePreviewContainer != null)
        {
            Destroy(cratePreviewContainer);
            cratePreviewContainer = null;
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
        fruitMaterialCache.Clear();
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


    private void InstantiateTileVisual(int gid, Vector2Int gridPos, Transform parent, float worldZ)
    {
        if (tiledIdToResourcePath.TryGetValue(gid, out string resPath))
        {
            GameObject tilePrefab = Resources.Load<GameObject>(resPath);
            if (tilePrefab != null)
            {
                Vector3 worldPos = new Vector3(gridPos.x, gridPos.y, worldZ);
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
        Bounds contentBounds = CalculateContentBounds(width, height);
        Vector3 center = contentBounds.center;
        float aspect = Mathf.Max(0.01f, cam.aspect);
        float verticalSize = (contentBounds.size.y * 0.5f) + cameraPadding;
        float horizontalSize = ((contentBounds.size.x * 0.5f) + cameraPadding) / aspect;

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = gameBackgroundColor;

        if (usePerspectiveCamera)
        {
            cam.orthographic = false;
            cam.fieldOfView = perspectiveFieldOfView;

            if (useFixedPerspectiveCameraPose)
            {
                cam.transform.position = fixedPerspectiveCameraPosition;
                cam.transform.rotation = Quaternion.Euler(fixedPerspectiveCameraEuler);
            }
            else
            {
                float fitSize = Mathf.Max(verticalSize, horizontalSize);
                float halfFovRadians = Mathf.Max(1f, perspectiveFieldOfView) * 0.5f * Mathf.Deg2Rad;
                float distance = fitSize / Mathf.Tan(halfFovRadians) * Mathf.Max(0.1f, perspectiveDistanceMultiplier);
                Vector3 lookTarget = center + perspectiveLookOffset;
                Vector3 cameraPosition = new Vector3(
                    center.x,
                    center.y - contentBounds.size.y * perspectiveVerticalOffset,
                    lookTarget.z - distance);

                cam.transform.position = cameraPosition;
                cam.transform.rotation = Quaternion.LookRotation(lookTarget - cameraPosition, Vector3.up);
            }
        }
        else
        {
            cam.orthographic = true;
            cam.orthographicSize = Mathf.Max(verticalSize, horizontalSize);
            cam.transform.position = new Vector3(center.x, center.y, -10f);
            cam.transform.rotation = Quaternion.identity;
        }

        Vector3 mapCenter = new Vector3((width - 1f) * 0.5f, -(height - 1f) * 0.5f, 0f);
        UpdateBackground(mapCenter, width, height);
    }

    private Bounds CalculateContentBounds(float width, float height)
    {
        Vector3 mapCenter = new Vector3((width - 1f) * 0.5f, -(height - 1f) * 0.5f, 0f);
        Bounds bounds = new Bounds(mapCenter, new Vector3(width, height, 0.1f));

        if (cratePreviewContainer != null)
        {
            EncapsulateRenderers(ref bounds, cratePreviewContainer);
        }

        return bounds;
    }

    private static void EncapsulateRenderers(ref Bounds bounds, GameObject root)
    {
        Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                bounds.Encapsulate(renderer.bounds);
            }
        }
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

    private void SpawnCratePreview()
    {
        if (!showCratePreview || activeMap == null)
        {
            return;
        }

        GameObject signPrefab = ResolvePrefab(nextCrateSignPrefab, "Assets/GameObject/NextCrateSign.prefab");
        List<CrateColumnPreviewData> columnPreviews = BuildCrateColumnPreviews();

        if (columnPreviews.Count == 0)
        {
            return;
        }

        float topY = cratePreviewOffset.y;
        cratePreviewContainer = new GameObject("CratePreview");
        cratePreviewContainer.transform.SetParent(boardContainer != null ? boardContainer.transform : transform, false);
        cratePreviewContainer.transform.position = Vector3.zero;

        List<Vector2Int> deliveryAnchors = GetDeliveryEndAnchors();
        float centerX = (activeMap.width - 1f) * 0.5f + cratePreviewOffset.x;
        float columnWidth = cratePreviewSpacing * 1.45f;
        float startX = centerX - (columnPreviews.Count - 1) * columnWidth * 0.5f;
        float signGap = Mathf.Max(0.75f, cratePreviewSpacing * 0.55f);
        for (int i = 0; i < columnPreviews.Count; i++)
        {
            CrateColumnPreviewData preview = columnPreviews[i];
            float crateX = i < deliveryAnchors.Count
                ? deliveryAnchors[i].x
                : startX + i * columnWidth + cratePreviewSpacing * 0.5f;

            if (signPrefab != null)
            {
                Vector3 signPosition = new Vector3(crateX - signGap, topY + 0.08f, -0.4f);
                GameObject sign = Instantiate(signPrefab, signPosition, Quaternion.identity, cratePreviewContainer.transform);
                sign.name = $"NextCrateSign_Preview_{i + 1}";
                sign.transform.localScale = Vector3.one * nextCrateSignScale;
                ApplyNextCrateSignSprites(sign, preview.Next.pillKind, preview.Next.pillKind);
            }

            GameObject cratePrefab = ResolvePrefab(GetBoxCratePrefab(preview.Current), GetBoxCrateAssetPath(preview.Current));
            if (cratePrefab != null)
            {
                Vector3 cratePosition = new Vector3(crateX, topY, -0.45f);
                GameObject crate = Instantiate(cratePrefab, cratePosition, Quaternion.identity, cratePreviewContainer.transform);
                crate.name = $"Box_Crate_Preview_{i + 1}";
                crate.transform.localScale = Vector3.one * boxCrateScale;
                ConfigureCratePreview(crate, preview.Current);
            }
        }
    }

    private List<Vector2Int> GetDeliveryEndAnchors()
    {
        List<Vector2Int> anchors = new List<Vector2Int>();
        foreach (KeyValuePair<Vector2Int, int> entry in gridMap)
        {
            if (entry.Value == 387)
            {
                anchors.Add(entry.Key);
            }
        }

        if (anchors.Count == 0)
        {
            foreach (KeyValuePair<Vector2Int, int> entry in gridMap)
            {
                if (entry.Value >= 295 && entry.Value <= 297)
                {
                    anchors.Add(entry.Key + Vector2Int.up);
                }
            }
        }

        anchors.Sort((a, b) => a.x != b.x ? a.x.CompareTo(b.x) : b.y.CompareTo(a.y));
        return anchors;
    }

    private void ConfigureCratePreview(GameObject crate, ManualCrateSetup crateData)
    {
        if (crate == null || crateData == null)
        {
            return;
        }

        Sprite crateSprite = GetPillIconSprite(crateData.pillKind);
        foreach (SpriteRenderer spriteRenderer in crate.GetComponentsInChildren<SpriteRenderer>(true))
        {
            if (spriteRenderer == null)
            {
                continue;
            }

            if (crateSprite != null && (spriteRenderer.name == "Fruit_Icon" || spriteRenderer.name == "CollectFruit"))
            {
                spriteRenderer.sprite = crateSprite;
                spriteRenderer.gameObject.SetActive(true);
            }
        }

        Transform defaultFruits = FindChildByName(crate.transform, "FruitsParent");
        if (defaultFruits != null)
        {
            defaultFruits.gameObject.SetActive(false);
        }

        Transform previewFruits = new GameObject("SandboxCrateFruitPreview").transform;
        previewFruits.SetParent(crate.transform, false);
        previewFruits.localPosition = Vector3.zero;
        previewFruits.localRotation = Quaternion.identity;
        previewFruits.localScale = Vector3.one;

        int fruitCount = Mathf.Clamp(crateData.requiredCount, 1, 9);
        for (int i = 0; i < fruitCount; i++)
        {
            int row = i / 3;
            int col = i % 3;
            Vector3 localPosition = new Vector3((col - 1) * 0.55f, 0.58f - row * 0.55f, -0.08f);
            GameObject fruit = null;
            if (pillPrefab != null)
            {
                fruit = Instantiate(pillPrefab, previewFruits);
                ActivatePillKindOnInstance(fruit, crateData.pillKind);
            }
            else if (useMeshFruitVisuals)
            {
                fruit = CreateMeshFruit(crateData.pillKind, Vector3.zero, Quaternion.Euler(fruitTiltEuler), 0.18f, previewFruits);
            }

            if (fruit == null)
            {
                continue;
            }

            fruit.name = $"CrateFruit_{crateData.pillKind}_{i + 1}";
            fruit.transform.localPosition = localPosition;
            fruit.transform.localRotation = Quaternion.Euler(fruitTiltEuler);
            fruit.transform.localScale = Vector3.one * 0.18f;
        }
    }

    private static Transform FindChildByName(Transform root, string childName)
    {
        if (root == null)
        {
            return null;
        }

        foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == childName)
            {
                return child;
            }
        }

        return null;
    }

    private struct CrateColumnPreviewData
    {
        public ManualCrateSetup Current;
        public ManualCrateSetup Next;
    }

    private List<CrateColumnPreviewData> BuildCrateColumnPreviews()
    {
        List<CrateColumnPreviewData> previews = new List<CrateColumnPreviewData>();
        List<ManualColumnSetup> columns = currentLevelData != null ? currentLevelData.manualColumns : null;
        if (columns == null)
        {
            return previews;
        }

        foreach (ManualColumnSetup column in columns)
        {
            if (column?.crates == null || column.crates.Count == 0)
            {
                continue;
            }

            ManualCrateSetup current = null;
            ManualCrateSetup next = null;
            foreach (ManualCrateSetup crate in column.crates)
            {
                if (crate == null)
                {
                    continue;
                }

                if (current == null)
                {
                    current = crate;
                }
                else
                {
                    next = crate;
                    break;
                }
            }

            if (current == null)
            {
                continue;
            }

            previews.Add(new CrateColumnPreviewData
            {
                Current = current,
                Next = next ?? current
            });
        }

        if (previews.Count == 0)
        {
            ManualCrateSetup fallback = new ManualCrateSetup { pillKind = PillKind.Strawberry, requiredCount = 9 };
            previews.Add(new CrateColumnPreviewData { Current = fallback, Next = fallback });
        }

        return previews;
    }

    private GameObject GetBoxCratePrefab(ManualCrateSetup crate)
    {
        int requiredCount = Mathf.Max(1, crate.requiredCount);
        if (requiredCount <= 9) return boxCrate9Prefab;
        if (requiredCount <= 18) return boxCrate18Prefab != null ? boxCrate18Prefab : boxCrate9Prefab;
        return boxCrate27Prefab != null ? boxCrate27Prefab : (boxCrate18Prefab != null ? boxCrate18Prefab : boxCrate9Prefab);
    }

    private static string GetBoxCrateAssetPath(ManualCrateSetup crate)
    {
        int requiredCount = Mathf.Max(1, crate.requiredCount);
        if (requiredCount <= 9) return "Assets/GameObject/Box_Crate_9.prefab";
        if (requiredCount <= 18) return "Assets/GameObject/Box_Crate_18.prefab";
        return "Assets/GameObject/Box_Crate_27.prefab";
    }

    private GameObject ResolvePrefab(GameObject assignedPrefab, string editorAssetPath)
    {
        if (assignedPrefab != null)
        {
            return assignedPrefab;
        }

#if UNITY_EDITOR
        return AssetDatabase.LoadAssetAtPath<GameObject>(editorAssetPath);
#else
        return null;
#endif
    }

    private void ApplyNextCrateSignSprites(GameObject sign, PillKind currentKind, PillKind nextKind)
    {
        Sprite currentSprite = GetPillIconSprite(currentKind);
        Sprite nextSprite = GetPillIconSprite(nextKind);

        foreach (SpriteRenderer spriteRenderer in sign.GetComponentsInChildren<SpriteRenderer>(true))
        {
            if (spriteRenderer == null)
            {
                continue;
            }

            if (currentSprite != null && spriteRenderer.name == "FruitIcon")
            {
                spriteRenderer.sprite = currentSprite;
                spriteRenderer.gameObject.SetActive(true);
            }
            else if (nextSprite != null && spriteRenderer.name == "FruitIconNext")
            {
                spriteRenderer.sprite = nextSprite;
                spriteRenderer.gameObject.SetActive(true);
            }
        }
    }

    private Sprite GetPillIconSprite(PillKind kind)
    {
        if (pillPrefab == null)
        {
            return null;
        }

        PillColorShape[] shapes = pillPrefab.GetComponentsInChildren<PillColorShape>(true);
        foreach (PillColorShape shape in shapes)
        {
            if (shape == null || shape.pillKind != kind)
            {
                continue;
            }

            SpriteRenderer spriteRenderer = shape.GetComponentInChildren<SpriteRenderer>(true);
            if (spriteRenderer != null && spriteRenderer.sprite != null)
            {
                return spriteRenderer.sprite;
            }
        }

        return null;
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
            : FindLevelIndex(levelMapName);

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

    private int FindLevelIndex(string mapName)
    {
        if (availableLevelNames == null || availableLevelNames.Length == 0)
        {
            return -1;
        }

        int exactIndex = Array.IndexOf(availableLevelNames, mapName);
        if (exactIndex >= 0)
        {
            return exactIndex;
        }

        string normalized = NormalizeLevelName(mapName);
        for (int i = 0; i < availableLevelNames.Length; i++)
        {
            if (NormalizeLevelName(availableLevelNames[i]) == normalized)
            {
                return i;
            }
        }

        return -1;
    }

    private static string NormalizeLevelName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        string trimmed = value.Trim();
        string[] parts = trimmed.Split(new[] { "_v" }, StringSplitOptions.None);
        if (parts.Length > 0 && int.TryParse(parts[0], out int levelNumber))
        {
            string suffix = parts.Length > 1 ? "_v" + parts[1] : string.Empty;
            return levelNumber + suffix;
        }

        return trimmed;
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

    private static bool IsInitialFruitSpawnTile(int gid)
    {
        return gid == 277 || gid == 276 || (gid >= 371 && gid <= 377);
    }

    private void SpawnInitialFruits(List<SpawnCellData> seedSlots)
    {
        if (seedSlots == null || seedSlots.Count == 0)
        {
            return;
        }

        List<PillKind> kinds = wave1SpawnKinds != null && wave1SpawnKinds.Count > 0
            ? wave1SpawnKinds
            : BuildKindsFromExplicitSlots(seedSlots);

        bool shouldFillFromWave = fillInitialWaveFromData &&
                                  kinds.Count > seedSlots.Count &&
                                  seedSlots.Count < initialWaveFillMarkerThreshold;
        int targetCount = shouldFillFromWave ? kinds.Count : seedSlots.Count;
        List<SpawnCellData> cells = BuildInitialFruitCells(seedSlots, targetCount);
        int count = Mathf.Min(targetCount, cells.Count);

        wave1SpawnKindIndex = 0;
        for (int i = 0; i < count; i++)
        {
            SpawnCellData cell = cells[i];
            int gid = cell.Gid == 276 && kinds.Count > 0 ? 277 : cell.Gid;
            SpawnFruitAtCell(gid, cell.GridPos, new Vector3(cell.GridPos.x, cell.GridPos.y, 0f));
        }
    }

    private static List<PillKind> BuildKindsFromExplicitSlots(List<SpawnCellData> seedSlots)
    {
        List<PillKind> kinds = new List<PillKind>();
        foreach (SpawnCellData slot in seedSlots)
        {
            if (slot.Gid >= 371 && slot.Gid <= 377)
            {
                kinds.Add((PillKind)(slot.Gid - 371));
            }
        }

        return kinds;
    }

    private List<SpawnCellData> BuildInitialFruitCells(List<SpawnCellData> seedSlots, int targetCount)
    {
        if (fillInitialWaveFromData &&
            targetCount > seedSlots.Count &&
            initialFruitPlacementMode == InitialFruitPlacementMode.SpreadAcrossPath)
        {
            return BuildSpreadInitialFruitCells(seedSlots, targetCount);
        }

        List<SpawnCellData> cells = new List<SpawnCellData>();
        HashSet<Vector2Int> used = new HashSet<Vector2Int>();
        Queue<Vector2Int> queue = new Queue<Vector2Int>();

        foreach (SpawnCellData slot in seedSlots)
        {
            if (used.Add(slot.GridPos))
            {
                cells.Add(slot);
                queue.Enqueue(slot.GridPos);
            }
        }

        if (!fillInitialWaveFromData || cells.Count >= targetCount)
        {
            return cells;
        }

        Vector2Int[] dirs = { Vector2Int.right, Vector2Int.down, Vector2Int.left, Vector2Int.up };
        while (queue.Count > 0 && cells.Count < targetCount)
        {
            Vector2Int origin = queue.Dequeue();
            foreach (Vector2Int dir in dirs)
            {
                Vector2Int next = origin + dir;
                if (!used.Add(next) || !IsInitialFruitPathCell(next))
                {
                    continue;
                }

                cells.Add(new SpawnCellData { Gid = 277, GridPos = next });
                queue.Enqueue(next);
                if (cells.Count >= targetCount)
                {
                    break;
                }
            }
        }

        return cells;
    }

    private List<SpawnCellData> BuildSpreadInitialFruitCells(List<SpawnCellData> seedSlots, int targetCount)
    {
        List<SpawnCellData> cells = new List<SpawnCellData>();
        HashSet<Vector2Int> used = new HashSet<Vector2Int>();

        foreach (SpawnCellData slot in seedSlots)
        {
            if (slot.Gid >= 371 && slot.Gid <= 377 && used.Add(slot.GridPos))
            {
                cells.Add(slot);
            }
        }

        List<Vector2Int> candidates = new List<Vector2Int>();
        foreach (Vector2Int gridPos in gridMap.Keys)
        {
            if (!used.Contains(gridPos) && IsInitialFruitPathCell(gridPos))
            {
                candidates.Add(gridPos);
            }
        }

        candidates.Sort(CompareInitialFruitCandidateCells);

        int remaining = targetCount - cells.Count;
        if (remaining <= 0)
        {
            return cells;
        }

        List<Vector2Int> picked = PickEvenlySpacedCells(candidates, remaining);
        foreach (Vector2Int gridPos in picked)
        {
            if (used.Add(gridPos))
            {
                cells.Add(new SpawnCellData { Gid = 277, GridPos = gridPos });
            }
        }

        return cells;
    }

    private static int CompareInitialFruitCandidateCells(Vector2Int a, Vector2Int b)
    {
        int yCompare = b.y.CompareTo(a.y);
        return yCompare != 0 ? yCompare : a.x.CompareTo(b.x);
    }

    private static List<Vector2Int> PickEvenlySpacedCells(List<Vector2Int> candidates, int count)
    {
        List<Vector2Int> picked = new List<Vector2Int>();
        if (candidates == null || candidates.Count == 0 || count <= 0)
        {
            return picked;
        }

        if (count >= candidates.Count)
        {
            picked.AddRange(candidates);
            return picked;
        }

        HashSet<int> pickedIndices = new HashSet<int>();
        float step = (candidates.Count - 1f) / Mathf.Max(1, count - 1);
        for (int i = 0; i < count; i++)
        {
            int index = Mathf.Clamp(Mathf.RoundToInt(i * step), 0, candidates.Count - 1);
            while (index < candidates.Count && !pickedIndices.Add(index))
            {
                index++;
            }

            if (index >= candidates.Count)
            {
                index = candidates.Count - 1;
                while (index >= 0 && !pickedIndices.Add(index))
                {
                    index--;
                }
            }

            if (index >= 0)
            {
                picked.Add(candidates[index]);
            }
        }

        picked.Sort(CompareInitialFruitCandidateCells);
        return picked;
    }

    private bool IsInitialFruitPathCell(Vector2Int gridPos)
    {
        if (spawnMap.TryGetValue(gridPos, out int spawnGid) && spawnGid == 287)
        {
            return false;
        }

        if (!gridMap.TryGetValue(gridPos, out int tileGid))
        {
            return false;
        }

        if (tileGid == 387 || (tileGid >= 295 && tileGid <= 297))
        {
            return false;
        }

        return tileGid == 347 || tileGid == 350 || tileGid == 352 ||
               tileGid == 353 || tileGid == 354 || tileGid == 355 || tileGid == 356;
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

        List<RespawnColorCount> remainingColors = new List<RespawnColorCount>();
        List<int> remainingCounts = new List<int>();

        foreach (var colorEntry in colors)
        {
            if (colorEntry == null) continue;
            int count = Mathf.Max(0, colorEntry.count);
            if (count <= 0) continue;

            remainingColors.Add(colorEntry);
            remainingCounts.Add(count);
        }

        bool hasRemaining;
        do
        {
            hasRemaining = false;
            for (int i = 0; i < remainingColors.Count; i++)
            {
                if (remainingCounts[i] <= 0) continue;

                result.Add(remainingColors[i].pillKind);
                remainingCounts[i]--;
                hasRemaining = true;
            }
        }
        while (hasRemaining);

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
        if (gid >= 371 && gid <= 377)
        {
            kind = (PillKind)(gid - 371);
        }
        else if (wave1SpawnKinds.Count > 0)
        {
            kind = wave1SpawnKinds[wave1SpawnKindIndex % wave1SpawnKinds.Count];
            wave1SpawnKindIndex++;
        }
        else
        {
            kind = PillKind.Strawberry; // fallback
        }

        GameObject pill = null;
        if (useMeshFruitVisuals)
        {
            pill = CreateMeshFruit(kind, worldPos, Quaternion.Euler(fruitTiltEuler), meshFruitScale, null);
            if (pill != null)
            {
                pill.name = $"Pill_{kind}_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
            }
        }

        // Thử dùng pillPrefab được gán trong Inspector (PillMaster)
        if (pill == null && pillPrefab != null)
        {
            pill = Instantiate(pillPrefab, worldPos, Quaternion.Euler(fruitTiltEuler));
            pill.name = $"Pill_{kind}_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
            ActivatePillKindOnInstance(pill, kind);
        }
        else if (pill == null)
        {
            // Fallback: sphere có màu theo loại fruit
            pill = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pill.name = $"Pill_{kind}_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
            pill.transform.position = worldPos;
            pill.transform.rotation = Quaternion.Euler(fruitTiltEuler);
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
            ApplyFruitTilt(pill);
            spawnedPills[gridPos] = pill;
        }
    }

    private void ApplyFruitTilt(GameObject pill)
    {
        if (pill == null)
        {
            return;
        }

        pill.transform.rotation = Quaternion.Euler(fruitTiltEuler);
    }

    private GameObject CreateMeshFruit(PillKind kind, Vector3 position, Quaternion rotation, float scale, Transform parent)
    {
        Mesh mesh = GetFruitMesh(kind);
        if (mesh == null || unlitShader == null)
        {
            return null;
        }

        GameObject fruit = new GameObject($"FruitMesh_{kind}");
        fruit.transform.SetParent(parent, false);
        fruit.transform.position = position;
        fruit.transform.rotation = rotation;
        fruit.transform.localScale = Vector3.one * scale;

        MeshFilter meshFilter = fruit.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = mesh;

        MeshRenderer meshRenderer = fruit.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = GetFruitMaterial(kind);
        return fruit;
    }

    private Mesh GetFruitMesh(PillKind kind)
    {
        if (fruitMeshCache.TryGetValue(kind, out Mesh cached))
        {
            return cached;
        }

        Mesh mesh = null;
#if UNITY_EDITOR
        string[] paths = GetFruitMeshPaths(kind);
        foreach (string path in paths)
        {
            mesh = AssetDatabase.LoadAssetAtPath<Mesh>(path);
            if (mesh != null)
            {
                break;
            }
        }
#endif
        fruitMeshCache[kind] = mesh;
        return mesh;
    }

    private Material GetFruitMaterial(PillKind kind)
    {
        if (fruitMaterialCache.TryGetValue(kind, out Material cached))
        {
            return cached;
        }

        Material mat = new Material(unlitShader);
        mat.name = $"Fruit_{kind}_Runtime";
        Color color = GetPillColor(kind);
        if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", color);
        if (mat.HasProperty("_Color")) mat.SetColor("_Color", color);
        SetCullOff(mat);

        fruitMaterialCache[kind] = mat;
        runtimeFruitMats.Add(mat);
        return mat;
    }

    private static string[] GetFruitMeshPaths(PillKind kind)
    {
        switch (kind)
        {
            case PillKind.Strawberry: return new[] { "Assets/Mesh/FruitMesh_Strawberry_red.asset" };
            case PillKind.Blueberry: return new[] { "Assets/Mesh/FruitMesh_Blueberry.asset", "Assets/Mesh/Blueberry.asset" };
            case PillKind.Banana: return new[] { "Assets/Mesh/Fruit_BananaV2.asset", "Assets/Mesh/FruitMesh_Banana.asset" };
            case PillKind.Pear: return new[] { "Assets/Mesh/Fruit_PearV2.asset", "Assets/Mesh/FruitMesh_Pear_yellow.asset" };
            case PillKind.Apple: return new[] { "Assets/Mesh/FruitMesh_Apple.asset", "Assets/Mesh/apple_lo.asset" };
            case PillKind.Carrot: return new[] { "Assets/Mesh/FruitMesh_Carrot.asset", "Assets/Mesh/Carrot.asset" };
            case PillKind.Eggplant: return new[] { "Assets/Mesh/FruitMesh_Eggplant.asset" };
            default: return Array.Empty<string>();
        }
    }

    private static void SetCullOff(Material mat)
    {
        if (mat == null)
        {
            return;
        }

        if (mat.HasProperty("_Cull")) mat.SetFloat("_Cull", 0f);
        if (mat.HasProperty("_CullMode")) mat.SetFloat("_CullMode", 0f);
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
        fruitMaterialCache.Clear();
    }
}
