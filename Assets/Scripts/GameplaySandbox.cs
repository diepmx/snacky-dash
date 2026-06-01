using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySandbox : MonoBehaviour
{
    [Header("Level Configuration")]
    [Tooltip("Tên file JSON màn chơi trong Resources/levelmaps/ (ví dụ: 11004_v1)")]
    public string levelMapName = "6070_v2";

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

    // Trạng thái game
    private TiledMap activeMap;
    private Dictionary<Vector2Int, int> gridMap = new Dictionary<Vector2Int, int>();
    private Dictionary<Vector2Int, int> spawnMap = new Dictionary<Vector2Int, int>();
    private Dictionary<int, string> tiledIdToResourcePath = new Dictionary<int, string>();
    private Dictionary<Vector2Int, GameObject> spawnedPills = new Dictionary<Vector2Int, GameObject>();
    private int tilesetFirstGid = 1;

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
    }

    private void Start()
    {
        // 2. Load và tạo Level
        LoadLevel();
    }

    private void Update()
    {
        // 3. Nhận diện thao tác điều khiển
        HandleInput();
    }

    // 1. Tự động parse YAML Database
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
        TextAsset mapText = Resources.Load<TextAsset>("levelmaps/" + levelMapName);
        if (mapText == null)
        {
            Debug.LogError("Không tìm thấy file level map JSON: Resources/levelmaps/" + levelMapName);
            return;
        }

        activeMap = JsonUtility.FromJson<TiledMap>(mapText.text);
        if (activeMap == null || activeMap.layers == null)
        {
            Debug.LogError("Lỗi parse map JSON.");
            return;
        }

        tilesetFirstGid = activeMap.tilesets != null && activeMap.tilesets.Count > 0
            ? Mathf.Max(1, activeMap.tilesets[0].firstgid)
            : 1;

        // Tạo container cha để gọn Hierarchy
        GameObject boardContainer = new GameObject("GameBoard");

        TiledLayer spawnLayer = activeMap.layers.Find(l => l.name == "spawn");

        // Dựng bản đồ từ tất cả layer tile gameplay, gồm map + ldf/obstacle layers.
        foreach (TiledLayer mapLayer in activeMap.layers)
        {
            if (mapLayer == null || mapLayer.data == null || mapLayer.name == "spawn" || mapLayer.name.StartsWith("spawn", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

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

        // Khởi tạo lịch sử vị trí của rắn tại điểm xuất phát
        snakePositionsHistory.Add(snakeGridPos);
        UpdateTailVisuals();
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
        // 277 = pill_spawn_point
        else if (gid == 277)
        {
            if (pillPrefab != null)
            {
                GameObject pill = Instantiate(pillPrefab, worldPos, Quaternion.identity);
                pill.name = $"Pill_{gridPos.x}_{Mathf.Abs(gridPos.y)}";
                spawnedPills[gridPos] = pill;
            }
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
}
