using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelViewer
{
    public class LevelViewerManager : MonoBehaviour
    {
        // --- Data ---
        private LevelCohortSO[] _cohorts;
        private string[] _cohortNames;
        private int _selectedCohortIndex;
        private int _selectedLevelIndex;
        private ParsedLevel _currentParsed;
        private LevelDataSO _currentLevelData;

        // --- Grid Texture ---
        private Texture2D _gridTexture;
        private const int TILE_PX = 20;
        private const int TILE_BORDER = 1;

        // --- UI State ---
        private Vector2 _levelListScroll;
        private Vector2 _infoScroll;
        private bool _showMapLayer = true;
        private bool _showLdfLayer = true;
        private bool _showSpawnLayer;
        private string _searchFilter = "";
        private bool _initialized;

        // --- Styles ---
        private GUIStyle _headerStyle;
        private GUIStyle _subHeaderStyle;
        private GUIStyle _levelBtnStyle;
        private GUIStyle _levelBtnSelectedStyle;
        private GUIStyle _boxStyle;
        private GUIStyle _legendStyle;
        private GUIStyle _smallLabelStyle;
        private bool _stylesBuilt;

        private void Start()
        {
            LoadCohorts();
            _initialized = true;
            if (_cohorts != null && _cohorts.Length > 0)
            {
                SelectCohort(0);
            }
        }

        private void LoadCohorts()
        {
            var loaded = Resources.LoadAll<LevelCohortSO>("cohorts");
            if (loaded == null || loaded.Length == 0)
            {
                Debug.LogWarning("[LevelViewer] No cohorts found in Resources/cohorts/");
                _cohorts = new LevelCohortSO[0];
                _cohortNames = new string[0];
                return;
            }

            _cohorts = loaded.OrderBy(c => c.cohortName).ToArray();
            _cohortNames = _cohorts.Select(c => c.cohortName ?? c.name).ToArray();
            Debug.Log($"[LevelViewer] Loaded {_cohorts.Length} cohorts");
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
                ClearTexture();
                return;
            }

            string levelName = _currentLevelData.name;
            var jsonAsset = Resources.Load<TextAsset>("levelmaps/" + levelName);
            if (jsonAsset != null)
            {
                _currentParsed = TiledMapParser.Parse(jsonAsset.text, levelName);
                RebuildTexture();
            }
            else
            {
                Debug.LogWarning($"[LevelViewer] No JSON found for level: {levelName}");
                _currentParsed = null;
                ClearTexture();
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

        // --- Grid Texture Rendering ---

        private void ClearTexture()
        {
            if (_gridTexture != null) Destroy(_gridTexture);
            _gridTexture = null;
        }

        private void RebuildTexture()
        {
            ClearTexture();
            if (_currentParsed == null) return;

            int w = _currentParsed.Width;
            int h = _currentParsed.Height;
            int texW = w * TILE_PX;
            int texH = h * TILE_PX;

            _gridTexture = new Texture2D(texW, texH, TextureFormat.RGBA32, false);
            _gridTexture.filterMode = FilterMode.Point;

            // Fill background
            var bgColor = new Color32(20, 20, 25, 255);
            var pixels = new Color32[texW * texH];
            for (int i = 0; i < pixels.Length; i++) pixels[i] = bgColor;

            // Draw map layer
            if (_showMapLayer && _currentParsed.MapData != null)
            {
                DrawLayerToPixels(pixels, texW, texH, w, h, _currentParsed.MapData, 1f);
            }

            // Draw LDF layer (overlay)
            if (_showLdfLayer && _currentParsed.LdfData != null)
            {
                DrawLayerToPixels(pixels, texW, texH, w, h, _currentParsed.LdfData, 1f);
            }

            // Draw spawn layers (overlay)
            if (_showSpawnLayer)
            {
                foreach (var spawnData in _currentParsed.SpawnLayers)
                {
                    if (spawnData != null)
                        DrawLayerToPixels(pixels, texW, texH, w, h, spawnData, 0.8f);
                }
            }

            _gridTexture.SetPixels32(pixels);
            _gridTexture.Apply();
        }

        private void DrawLayerToPixels(Color32[] pixels, int texW, int texH, int gridW, int gridH, int[] data, float alpha)
        {
            for (int i = 0; i < data.Length && i < gridW * gridH; i++)
            {
                int tileId = data[i];
                if (tileId == 0) continue;

                int gx = i % gridW;
                int gy = i / gridW;

                var info = TileIdMapping.Get(tileId);
                Color32 col = info.Color;
                if (alpha < 1f)
                {
                    col.a = (byte)(col.a * alpha);
                }

                // Draw tile rect (flipped Y: Tiled is top-down, texture is bottom-up)
                int flippedY = gridH - 1 - gy;
                int startX = gx * TILE_PX + TILE_BORDER;
                int startY = flippedY * TILE_PX + TILE_BORDER;
                int size = TILE_PX - TILE_BORDER * 2;

                for (int py = 0; py < size; py++)
                {
                    for (int px = 0; px < size; px++)
                    {
                        int pixX = startX + px;
                        int pixY = startY + py;
                        if (pixX >= 0 && pixX < texW && pixY >= 0 && pixY < texH)
                        {
                            int idx = pixY * texW + pixX;
                            if (alpha >= 1f || col.a >= 200)
                            {
                                pixels[idx] = col;
                            }
                            else
                            {
                                // Simple alpha blend
                                var bg = pixels[idx];
                                float a = col.a / 255f;
                                pixels[idx] = new Color32(
                                    (byte)(bg.r * (1 - a) + col.r * a),
                                    (byte)(bg.g * (1 - a) + col.g * a),
                                    (byte)(bg.b * (1 - a) + col.b * a),
                                    255
                                );
                            }
                        }
                    }
                }
            }
        }

        // --- OnGUI ---

        private void BuildStyles()
        {
            if (_stylesBuilt) return;
            _stylesBuilt = true;

            _headerStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 22,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter
            };
            _headerStyle.normal.textColor = new Color(0.9f, 0.85f, 0.7f);

            _subHeaderStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold
            };
            _subHeaderStyle.normal.textColor = new Color(0.8f, 0.8f, 0.9f);

            _levelBtnStyle = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleLeft,
                fontSize = 11,
                fixedHeight = 24,
                padding = new RectOffset(8, 4, 2, 2)
            };

            _levelBtnSelectedStyle = new GUIStyle(_levelBtnStyle);
            _levelBtnSelectedStyle.normal.textColor = Color.yellow;
            _levelBtnSelectedStyle.fontStyle = FontStyle.Bold;

            _boxStyle = new GUIStyle(GUI.skin.box)
            {
                padding = new RectOffset(8, 8, 8, 8)
            };

            _legendStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 10,
                padding = new RectOffset(2, 2, 1, 1)
            };

            _smallLabelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 11
            };
        }

        private void OnGUI()
        {
            if (!_initialized) return;
            BuildStyles();

            float sw = Screen.width;
            float sh = Screen.height;
            float leftW = 240;
            float rightW = 260;
            float centerW = sw - leftW - rightW;
            float headerH = 40;

            // === HEADER ===
            GUI.Box(new Rect(0, 0, sw, headerH), "");
            GUI.Label(new Rect(0, 0, sw, headerH), "🎮  SNACKY DASH - Level Viewer", _headerStyle);

            float contentY = headerH;
            float contentH = sh - headerH;

            // === LEFT PANEL ===
            DrawLeftPanel(new Rect(0, contentY, leftW, contentH));

            // === CENTER PANEL ===
            DrawCenterPanel(new Rect(leftW, contentY, centerW, contentH));

            // === RIGHT PANEL ===
            DrawRightPanel(new Rect(sw - rightW, contentY, rightW, contentH));
        }

        private void DrawLeftPanel(Rect area)
        {
            GUILayout.BeginArea(area, _boxStyle);

            // Cohort selector
            GUILayout.Label("COHORT", _subHeaderStyle);
            if (_cohortNames != null && _cohortNames.Length > 0)
            {
                int newIdx = EditorLikePopup(_selectedCohortIndex, _cohortNames);
                if (newIdx != _selectedCohortIndex)
                {
                    SelectCohort(newIdx);
                }
            }

            GUILayout.Space(8);

            // Search
            GUILayout.Label("Search:", _smallLabelStyle);
            string newSearch = GUILayout.TextField(_searchFilter, GUILayout.Height(22));
            if (newSearch != _searchFilter)
            {
                _searchFilter = newSearch;
                _selectedLevelIndex = 0;
            }

            GUILayout.Space(4);

            // Level count
            var filtered = GetFilteredLevels();
            GUILayout.Label($"Levels: {filtered.Count}", _smallLabelStyle);

            GUILayout.Space(4);

            // Level list
            _levelListScroll = GUILayout.BeginScrollView(_levelListScroll, false, true);
            for (int i = 0; i < filtered.Count; i++)
            {
                var level = filtered[i];
                string label = level != null ? level.name : "(null)";
                bool isSelected = (i == _selectedLevelIndex);
                var style = isSelected ? _levelBtnSelectedStyle : _levelBtnStyle;

                if (GUILayout.Button((isSelected ? "► " : "  ") + label, style))
                {
                    SelectLevel(i);
                }
            }
            GUILayout.EndScrollView();

            GUILayout.Space(4);

            // Navigation
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("◄ Prev", GUILayout.Height(28)))
            {
                if (_selectedLevelIndex > 0)
                    SelectLevel(_selectedLevelIndex - 1);
            }
            if (GUILayout.Button("Next ►", GUILayout.Height(28)))
            {
                if (_selectedLevelIndex < filtered.Count - 1)
                    SelectLevel(_selectedLevelIndex + 1);
            }
            GUILayout.EndHorizontal();

            // Jump by 10
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("◄◄ -10", GUILayout.Height(22)))
            {
                SelectLevel(Mathf.Max(0, _selectedLevelIndex - 10));
            }
            if (GUILayout.Button("+10 ►►", GUILayout.Height(22)))
            {
                SelectLevel(Mathf.Min(filtered.Count - 1, _selectedLevelIndex + 10));
            }
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        private void DrawCenterPanel(Rect area)
        {
            GUI.Box(area, "");

            if (_gridTexture == null)
            {
                GUI.Label(new Rect(area.x + 20, area.y + area.height / 2 - 15, area.width - 40, 30),
                    "Select a level to display its tile grid",
                    new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 16 });
                return;
            }

            // Scale texture to fit area with padding
            float pad = 20;
            float availW = area.width - pad * 2;
            float availH = area.height - pad * 2 - 30; // reserve space for label

            float texAspect = (float)_gridTexture.width / _gridTexture.height;
            float areaAspect = availW / availH;

            float drawW, drawH;
            if (texAspect > areaAspect)
            {
                drawW = availW;
                drawH = availW / texAspect;
            }
            else
            {
                drawH = availH;
                drawW = availH * texAspect;
            }

            float drawX = area.x + (area.width - drawW) / 2;
            float drawY = area.y + pad + 25;

            // Title
            string title = _currentParsed != null
                ? $"{_currentParsed.LevelName}  ({_currentParsed.Width}×{_currentParsed.Height})"
                : "";
            GUI.Label(new Rect(area.x, area.y + 5, area.width, 25),
                title,
                new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 14, fontStyle = FontStyle.Bold });

            GUI.DrawTexture(new Rect(drawX, drawY, drawW, drawH), _gridTexture, ScaleMode.StretchToFill);

            // Tooltip on hover
            if (_currentParsed != null)
            {
                var mousePos = Event.current.mousePosition;
                if (mousePos.x >= drawX && mousePos.x <= drawX + drawW &&
                    mousePos.y >= drawY && mousePos.y <= drawY + drawH)
                {
                    float relX = (mousePos.x - drawX) / drawW;
                    float relY = (mousePos.y - drawY) / drawH;
                    int gx = (int)(relX * _currentParsed.Width);
                    int gy = (int)(relY * _currentParsed.Height);

                    if (gx >= 0 && gx < _currentParsed.Width && gy >= 0 && gy < _currentParsed.Height)
                    {
                        int idx = gy * _currentParsed.Width + gx;
                        string tooltip = $"({gx},{gy})";

                        if (_currentParsed.MapData != null && idx < _currentParsed.MapData.Length)
                        {
                            int tid = _currentParsed.MapData[idx];
                            var info = TileIdMapping.Get(tid);
                            tooltip += $" Map:{info.Name}[{tid}]";
                        }
                        if (_currentParsed.LdfData != null && idx < _currentParsed.LdfData.Length)
                        {
                            int tid = _currentParsed.LdfData[idx];
                            if (tid != 0)
                            {
                                var info = TileIdMapping.Get(tid);
                                tooltip += $" LDF:{info.Name}[{tid}]";
                            }
                        }

                        var tooltipRect = new Rect(mousePos.x + 15, mousePos.y - 10, 300, 22);
                        GUI.Box(tooltipRect, "");
                        GUI.Label(tooltipRect, tooltip, _smallLabelStyle);
                    }
                }
            }
        }

        private void DrawRightPanel(Rect area)
        {
            GUILayout.BeginArea(area, _boxStyle);
            _infoScroll = GUILayout.BeginScrollView(_infoScroll);

            // Level Info
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
                InfoRow("LDF Tutorial", _currentLevelData.hasLdfTutorialForThisLevel ? _currentLevelData.ldfTutorialIngredientType.ToString() : "None");

                if (_currentLevelData.manualColumns != null)
                {
                    InfoRow("Columns", _currentLevelData.manualColumns.Count.ToString());
                }
            }

            if (_currentParsed != null)
            {
                GUILayout.Space(4);
                InfoRow("Grid W", _currentParsed.Width.ToString());
                InfoRow("Grid H", _currentParsed.Height.ToString());
                InfoRow("Spawn Layers", _currentParsed.SpawnLayers.Count.ToString());

                // Tile stats
                if (_currentParsed.MapData != null)
                {
                    GUILayout.Space(4);
                    GUILayout.Label("TILE STATS", _subHeaderStyle);
                    var stats = new Dictionary<TileDisplayCategory, int>();
                    foreach (int tid in _currentParsed.MapData)
                    {
                        if (tid == 0) continue;
                        var info = TileIdMapping.Get(tid);
                        if (!stats.ContainsKey(info.Category)) stats[info.Category] = 0;
                        stats[info.Category]++;
                    }
                    if (_currentParsed.LdfData != null)
                    {
                        foreach (int tid in _currentParsed.LdfData)
                        {
                            if (tid == 0) continue;
                            var info = TileIdMapping.Get(tid);
                            if (!stats.ContainsKey(info.Category)) stats[info.Category] = 0;
                            stats[info.Category]++;
                        }
                    }
                    foreach (var kv in stats.OrderByDescending(x => x.Value))
                    {
                        var col = TileIdMapping.GetCategoryColor(kv.Key);
                        var oldColor = GUI.color;
                        GUI.color = new Color(col.r / 255f, col.g / 255f, col.b / 255f);
                        GUILayout.Label($"■ {kv.Key}: {kv.Value}", _legendStyle);
                        GUI.color = oldColor;
                    }
                }
            }

            GUILayout.Space(12);

            // Layer toggles
            GUILayout.Label("LAYERS", _subHeaderStyle);
            bool newMap = GUILayout.Toggle(_showMapLayer, " Map Layer");
            bool newLdf = GUILayout.Toggle(_showLdfLayer, " LDF Layer (Obstacles)");
            bool newSpawn = GUILayout.Toggle(_showSpawnLayer, " Spawn Layers");
            if (newMap != _showMapLayer || newLdf != _showLdfLayer || newSpawn != _showSpawnLayer)
            {
                _showMapLayer = newMap;
                _showLdfLayer = newLdf;
                _showSpawnLayer = newSpawn;
                RebuildTexture();
            }

            GUILayout.Space(12);

            // Legend
            GUILayout.Label("LEGEND", _subHeaderStyle);
            DrawLegendItem("Grass", TileDisplayCategory.Grass);
            DrawLegendItem("Path", TileDisplayCategory.Path);
            DrawLegendItem("Stop/Cross", TileDisplayCategory.Stop);
            DrawLegendItem("Crate Deliver", TileDisplayCategory.CrateDeliver);
            DrawLegendItem("Tunnel", TileDisplayCategory.Tunnel);
            DrawLegendItem("Arrow", TileDisplayCategory.Arrow);
            DrawLegendItem("Fixed Arrow", TileDisplayCategory.FixedArrow);
            DrawLegendItem("Bridge", TileDisplayCategory.Bridge);
            DrawLegendItem("Turnout", TileDisplayCategory.Turnout);
            DrawLegendItem("Destr. Wall", TileDisplayCategory.DestructibleWall);
            DrawLegendItem("Rising Block", TileDisplayCategory.RisingBlock);
            DrawLegendItem("Switch", TileDisplayCategory.Switch);
            DrawLegendItem("Player Start", TileDisplayCategory.PlayerStart);
            DrawLegendItem("Pill Spawn", TileDisplayCategory.PillSpawn);
            DrawLegendItem("Secret", TileDisplayCategory.SecretCollectible);
            DrawLegendItem("Unknown", TileDisplayCategory.Unknown);

            GUILayout.Space(8);

            // Cohort info
            if (_cohorts != null && _selectedCohortIndex < _cohorts.Length)
            {
                var c = _cohorts[_selectedCohortIndex];
                GUILayout.Label("COHORT INFO", _subHeaderStyle);
                InfoRow("Name", c.cohortName);
                InfoRow("Total Levels", c.levels != null ? c.levels.Count.ToString() : "0");
                InfoRow("Is Loop", c.isLoop.ToString());
                InfoRow("Loop Start", c.loopStartIndex.ToString());
            }

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        // --- UI Helpers ---

        private void InfoRow(string label, string value)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label + ":", _smallLabelStyle, GUILayout.Width(100));
            GUILayout.Label(value, _smallLabelStyle);
            GUILayout.EndHorizontal();
        }

        private void DrawLegendItem(string label, TileDisplayCategory cat)
        {
            var col = TileIdMapping.GetCategoryColor(cat);
            var oldColor = GUI.color;
            GUI.color = new Color(col.r / 255f, col.g / 255f, col.b / 255f);
            GUILayout.Label($"■ {label}", _legendStyle);
            GUI.color = oldColor;
        }

        private int EditorLikePopup(int selected, string[] options)
        {
            GUILayout.BeginHorizontal();
            string current = selected >= 0 && selected < options.Length ? options[selected] : "---";
            GUILayout.Label(current, GUI.skin.textField, GUILayout.Height(22));

            if (GUILayout.Button("◄", GUILayout.Width(25), GUILayout.Height(22)))
            {
                selected = Mathf.Max(0, selected - 1);
            }
            if (GUILayout.Button("►", GUILayout.Width(25), GUILayout.Height(22)))
            {
                selected = Mathf.Min(options.Length - 1, selected + 1);
            }
            GUILayout.EndHorizontal();
            return selected;
        }

        private void OnDestroy()
        {
            ClearTexture();
        }
    }
}
