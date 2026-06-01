using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewer
{
    public enum TileDisplayCategory
    {
        Empty,
        Grass,
        Path,
        PathNoPill,
        Corner,
        Stop,
        CrateDeliver,
        Tunnel,
        Arrow,
        FixedArrow,
        Bridge,
        SwitchBridge,
        Turnout,
        DestructibleWall,
        RoadBlock,
        RisingBlock,
        Switch,
        SwitchArc,
        PlayerStart,
        PillSpawn,
        NoPillSpawn,
        Connection,
        SecretCollectible,
        Unknown
    }

    public class TileDisplayInfo
    {
        public string Name;
        public TileDisplayCategory Category;
        public Color32 Color;
        public string Label;

        public TileDisplayInfo(string name, TileDisplayCategory cat, Color32 color, string label = "")
        {
            Name = name;
            Category = cat;
            Color = color;
            Label = string.IsNullOrEmpty(label) ? name : label;
        }
    }

    [Serializable]
    public class TiledMap
    {
        public int width;
        public int height;
        public TiledLayer[] layers;
        public TiledTileset[] tilesets;
    }

    [Serializable]
    public class TiledLayer
    {
        public int[] data;
        public int width;
        public int height;
        public int id;
        public string name;
        public string type;
        public bool visible;
    }

    [Serializable]
    public class TiledTileset
    {
        public int firstgid;
        public string source;
    }

    public class ParsedLevel
    {
        public string LevelName;
        public int Width;
        public int Height;
        public int[] MapData;
        public int[] LdfData;
        public List<int[]> SpawnLayers = new List<int[]>();
        public List<string> SpawnLayerNames = new List<string>();
    }

    public static class TiledMapParser
    {
        public static ParsedLevel Parse(string json, string levelName)
        {
            if (string.IsNullOrEmpty(json)) return null;

            TiledMap map;
            try
            {
                map = JsonUtility.FromJson<TiledMap>(json);
            }
            catch (Exception e)
            {
                Debug.LogError($"[LevelViewer] Failed to parse JSON for {levelName}: {e.Message}");
                return null;
            }

            if (map == null || map.layers == null) return null;

            var parsed = new ParsedLevel
            {
                LevelName = levelName,
                Width = map.width,
                Height = map.height
            };

            foreach (var layer in map.layers)
            {
                if (layer == null || layer.data == null) continue;

                string layerName = layer.name != null ? layer.name.ToLowerInvariant() : "";

                if (layerName == "map")
                {
                    parsed.MapData = layer.data;
                }
                else if (layerName == "ldf")
                {
                    parsed.LdfData = layer.data;
                }
                else if (layerName.StartsWith("spawn"))
                {
                    parsed.SpawnLayers.Add(layer.data);
                    parsed.SpawnLayerNames.Add(layer.name);
                }
            }

            return parsed;
        }
    }

    public static class TileIdMapping
    {
        private static Dictionary<int, TileDisplayInfo> _mapping;
        private static readonly Color32 COL_EMPTY = new Color32(30, 30, 30, 255);
        private static readonly Color32 COL_GRASS = new Color32(76, 153, 76, 255);
        private static readonly Color32 COL_GRASS_BORDER = new Color32(56, 120, 56, 255);
        private static readonly Color32 COL_GRASS_CORNER = new Color32(66, 136, 66, 255);
        private static readonly Color32 COL_PATH = new Color32(180, 160, 120, 255);
        private static readonly Color32 COL_PATH_NOPILL = new Color32(150, 135, 105, 255);
        private static readonly Color32 COL_CORNER_PATH = new Color32(200, 180, 140, 255);
        private static readonly Color32 COL_STOP = new Color32(240, 200, 60, 255);
        private static readonly Color32 COL_CRATE = new Color32(220, 60, 60, 255);
        private static readonly Color32 COL_CRATE1 = new Color32(200, 80, 40, 255);
        private static readonly Color32 COL_CRATE2 = new Color32(180, 50, 80, 255);
        private static readonly Color32 COL_TUNNEL_A = new Color32(60, 140, 220, 255);
        private static readonly Color32 COL_TUNNEL_B = new Color32(80, 160, 240, 255);
        private static readonly Color32 COL_TUNNEL_C = new Color32(40, 120, 200, 255);
        private static readonly Color32 COL_TUNNEL_D = new Color32(100, 180, 255, 255);
        private static readonly Color32 COL_ARROW = new Color32(255, 160, 40, 255);
        private static readonly Color32 COL_FIXED_ARROW = new Color32(230, 120, 20, 255);
        private static readonly Color32 COL_BRIDGE = new Color32(200, 200, 220, 255);
        private static readonly Color32 COL_SWITCH_BRIDGE = new Color32(170, 170, 210, 255);
        private static readonly Color32 COL_TURNOUT = new Color32(200, 100, 200, 255);
        private static readonly Color32 COL_DEST_WALL = new Color32(140, 90, 50, 255);
        private static readonly Color32 COL_ROADBLOCK = new Color32(120, 70, 40, 255);
        private static readonly Color32 COL_RISING = new Color32(160, 110, 70, 255);
        private static readonly Color32 COL_SWITCH = new Color32(100, 200, 200, 255);
        private static readonly Color32 COL_PLAYER = new Color32(180, 60, 220, 255);
        private static readonly Color32 COL_PILLSPAWN = new Color32(255, 120, 180, 255);
        private static readonly Color32 COL_NOPILLSPAWN = new Color32(100, 80, 80, 255);
        private static readonly Color32 COL_CONNECTION = new Color32(160, 220, 160, 255);
        private static readonly Color32 COL_SECRET = new Color32(255, 215, 0, 255);
        private static readonly Color32 COL_TOGGLE = new Color32(130, 190, 130, 255);
        private static readonly Color32 COL_UNKNOWN = new Color32(255, 0, 255, 255);

        public static TileDisplayInfo Get(int tiledId)
        {
            if (_mapping == null) BuildMapping();
            if (_mapping.TryGetValue(tiledId, out var info)) return info;
            return new TileDisplayInfo($"?{tiledId}", TileDisplayCategory.Unknown, COL_UNKNOWN, $"?{tiledId}");
        }

        public static Dictionary<int, TileDisplayInfo> GetAll()
        {
            if (_mapping == null) BuildMapping();
            return _mapping;
        }

        private static void Add(int id, string name, TileDisplayCategory cat, Color32 col, string label = "")
        {
            _mapping[id] = new TileDisplayInfo(name, cat, col, label);
        }

        private static void BuildMapping()
        {
            _mapping = new Dictionary<int, TileDisplayInfo>();

            // 0 = Empty
            Add(0, "Empty", TileDisplayCategory.Empty, COL_EMPTY);

            // === GRASS TILES (category 1) ===
            Add(322, "Border_D", TileDisplayCategory.Grass, COL_GRASS_BORDER);
            Add(323, "Border_L", TileDisplayCategory.Grass, COL_GRASS_BORDER);
            Add(324, "Border_R", TileDisplayCategory.Grass, COL_GRASS_BORDER);
            Add(325, "Border_U", TileDisplayCategory.Grass, COL_GRASS_BORDER);
            Add(326, "CornerExt_LD", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(327, "CornerExt_LU", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(328, "CornerExt_RD", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(329, "CornerExt_RU", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(330, "CornerInt_LD_noP", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(331, "CornerInt_LD", TileDisplayCategory.Corner, COL_CORNER_PATH, "\u2199");
            Add(332, "CornerInt_LU_noP", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(333, "CornerInt_LU", TileDisplayCategory.Corner, COL_CORNER_PATH, "\u2196");
            Add(334, "CornerInt_RD_noP", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(335, "CornerInt_RD", TileDisplayCategory.Corner, COL_CORNER_PATH, "\u2198");
            Add(336, "CornerInt_RU_noP", TileDisplayCategory.Grass, COL_GRASS_CORNER);
            Add(337, "CornerInt_RU", TileDisplayCategory.Corner, COL_CORNER_PATH, "\u2197");
            Add(338, "Island_End_D", TileDisplayCategory.Grass, COL_GRASS);
            Add(339, "Island_End_L", TileDisplayCategory.Grass, COL_GRASS);
            Add(340, "Island_End_R", TileDisplayCategory.Grass, COL_GRASS);
            Add(341, "Island_End_U", TileDisplayCategory.Grass, COL_GRASS);
            Add(342, "Island_FlatTop", TileDisplayCategory.Grass, COL_GRASS);
            Add(343, "Island_Mid_LR", TileDisplayCategory.Grass, COL_GRASS);
            Add(344, "Island_Mid_UD", TileDisplayCategory.Grass, COL_GRASS);
            Add(345, "Island_Single", TileDisplayCategory.Grass, COL_GRASS);
            Add(348, "Cross_Special", TileDisplayCategory.Stop, COL_STOP);

            // === PATH TILES (category 2) ===
            Add(347, "Cross", TileDisplayCategory.Stop, COL_STOP, "+");
            Add(349, "RL_NoPill", TileDisplayCategory.PathNoPill, COL_PATH_NOPILL, "\u2194");
            Add(350, "RL", TileDisplayCategory.Path, COL_PATH, "\u2194");
            Add(351, "UD_NoPill", TileDisplayCategory.PathNoPill, COL_PATH_NOPILL, "\u2195");
            Add(352, "UD", TileDisplayCategory.Path, COL_PATH, "\u2195");
            Add(353, "CrossR", TileDisplayCategory.Stop, COL_STOP, "\u251c");
            Add(354, "CrossU", TileDisplayCategory.Stop, COL_STOP, "\u2534");
            Add(355, "CrossD", TileDisplayCategory.Stop, COL_STOP, "\u252c");
            Add(356, "CrossL", TileDisplayCategory.Stop, COL_STOP, "\u2524");
            Add(388, "Cross_Start", TileDisplayCategory.Stop, COL_STOP, "S");

            // === CRATE DELIVERY (category 5) ===
            Add(295, "Crate_0", TileDisplayCategory.CrateDeliver, COL_CRATE, "C0");
            Add(296, "Crate_1", TileDisplayCategory.CrateDeliver, COL_CRATE1, "C1");
            Add(297, "Crate_2", TileDisplayCategory.CrateDeliver, COL_CRATE2, "C2");

            // === STOP ===
            Add(294, "Stop", TileDisplayCategory.Stop, COL_STOP, "X");

            // === TUNNEL (category 3) ===
            Add(278, "Tunnel_L_A", TileDisplayCategory.Tunnel, COL_TUNNEL_A, "\u2190A");
            Add(279, "Tunnel_U_A", TileDisplayCategory.Tunnel, COL_TUNNEL_A, "\u2191A");
            Add(280, "Tunnel_R_A", TileDisplayCategory.Tunnel, COL_TUNNEL_A, "\u2192A");
            Add(281, "Tunnel_D_A", TileDisplayCategory.Tunnel, COL_TUNNEL_A, "\u2193A");
            Add(360, "Tunnel_D_B", TileDisplayCategory.Tunnel, COL_TUNNEL_B, "\u2193B");
            Add(361, "Tunnel_L_B", TileDisplayCategory.Tunnel, COL_TUNNEL_B, "\u2190B");
            Add(362, "Tunnel_R_B", TileDisplayCategory.Tunnel, COL_TUNNEL_B, "\u2192B");
            Add(363, "Tunnel_U_B", TileDisplayCategory.Tunnel, COL_TUNNEL_B, "\u2191B");
            Add(384, "Tunnel_D_C", TileDisplayCategory.Tunnel, COL_TUNNEL_C, "\u2193C");
            Add(385, "Tunnel_L_C", TileDisplayCategory.Tunnel, COL_TUNNEL_C, "\u2190C");
            Add(386, "Tunnel_R_C", TileDisplayCategory.Tunnel, COL_TUNNEL_C, "\u2192C");
            Add(382, "Tunnel_U_C", TileDisplayCategory.Tunnel, COL_TUNNEL_C, "\u2191C");
            Add(380, "Tunnel_D_D", TileDisplayCategory.Tunnel, COL_TUNNEL_D, "\u2193D");
            Add(379, "Tunnel_L_D", TileDisplayCategory.Tunnel, COL_TUNNEL_D, "\u2190D");
            Add(381, "Tunnel_R_D", TileDisplayCategory.Tunnel, COL_TUNNEL_D, "\u2192D");
            Add(378, "Tunnel_U_D", TileDisplayCategory.Tunnel, COL_TUNNEL_D, "\u2191D");

            // === ARROWS (category 4) - Flipping ===
            Add(303, "Arrow_L", TileDisplayCategory.Arrow, COL_ARROW, "\u2190");
            Add(301, "Arrow_L_1", TileDisplayCategory.Arrow, COL_ARROW, "\u2190");
            Add(306, "Arrow_R", TileDisplayCategory.Arrow, COL_ARROW, "\u2192");
            Add(304, "Arrow_R_1", TileDisplayCategory.Arrow, COL_ARROW, "\u2192");
            Add(300, "Arrow_D", TileDisplayCategory.Arrow, COL_ARROW, "\u2193");
            Add(298, "Arrow_D_1", TileDisplayCategory.Arrow, COL_ARROW, "\u2193");
            Add(309, "Arrow_U", TileDisplayCategory.Arrow, COL_ARROW, "\u2191");
            Add(307, "Arrow_U_1", TileDisplayCategory.Arrow, COL_ARROW, "\u2191");

            // === ARROWS - Fixed ===
            Add(302, "FxArrow_L", TileDisplayCategory.FixedArrow, COL_FIXED_ARROW, "\u21d0");
            Add(305, "FxArrow_R", TileDisplayCategory.FixedArrow, COL_FIXED_ARROW, "\u21d2");
            Add(299, "FxArrow_D", TileDisplayCategory.FixedArrow, COL_FIXED_ARROW, "\u21d3");
            Add(308, "FxArrow_U", TileDisplayCategory.FixedArrow, COL_FIXED_ARROW, "\u21d1");

            // === BRIDGE ===
            Add(357, "Bridge_UD", TileDisplayCategory.Bridge, COL_BRIDGE, "B\u2195");
            Add(359, "Bridge_LR", TileDisplayCategory.Bridge, COL_BRIDGE, "B\u2194");
            Add(358, "SwitchBridge_LR", TileDisplayCategory.SwitchBridge, COL_SWITCH_BRIDGE, "SB");

            // === TURNOUT / AIGUILLAGE (category 7) ===
            Add(320, "Turn_Up_L", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(321, "Turn_Up_R", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(318, "Turn_UP_RL", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(317, "Turn_UP_RL2", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(311, "Turn_DN_RL", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(312, "Turn_DN_RL2", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(313, "Turn_L_UD", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(314, "Turn_L_UD2", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(316, "Turn_R_UD", TileDisplayCategory.Turnout, COL_TURNOUT, "T");
            Add(315, "Turn_R_UD2", TileDisplayCategory.Turnout, COL_TURNOUT, "T");

            // === DESTRUCTIBLE WALL (category 8) ===
            Add(291, "DWall_V", TileDisplayCategory.DestructibleWall, COL_DEST_WALL, "W\u2195");
            Add(283, "DWall_H", TileDisplayCategory.DestructibleWall, COL_DEST_WALL, "W\u2194");

            // === ROAD BLOCK / RISING BLOCK ===
            Add(286, "RoadBlock", TileDisplayCategory.RoadBlock, COL_ROADBLOCK, "RB");
            Add(285, "RisingBlock", TileDisplayCategory.RisingBlock, COL_RISING, "\u2b06");

            // === SWITCH ===
            Add(290, "Switch", TileDisplayCategory.Switch, COL_SWITCH, "SW");
            Add(292, "SwitchArc", TileDisplayCategory.SwitchArc, COL_TOGGLE, "SA");
            Add(346, "CrossToggle", TileDisplayCategory.Switch, COL_TOGGLE, "TG");

            // === PLAYER START ===
            Add(287, "PlayerStart", TileDisplayCategory.PlayerStart, COL_PLAYER, "P");
            Add(288, "PlayerStart2", TileDisplayCategory.PlayerStart, COL_PLAYER, "P");

            // === PILL SPAWN ===
            Add(277, "PillSpawn", TileDisplayCategory.PillSpawn, COL_PILLSPAWN, "\u25cf");
            Add(372, "PillSpawn1", TileDisplayCategory.PillSpawn, COL_PILLSPAWN, "\u25cf");
            Add(373, "PillSpawn2", TileDisplayCategory.PillSpawn, COL_PILLSPAWN, "\u25cb");
            Add(276, "NoPillSpawn", TileDisplayCategory.NoPillSpawn, COL_NOPILLSPAWN, "\u25cc");

            // === CONNECTION / MISC ===
            Add(319, "Connection", TileDisplayCategory.Connection, COL_CONNECTION, "CN");
            Add(387, "DeliveryEnd", TileDisplayCategory.Connection, COL_CONNECTION, "DE");
            Add(389, "Secret", TileDisplayCategory.SecretCollectible, COL_SECRET, "\u2605");

            // === Spawn marker IDs (seen in spawn layers) ===
            Add(282, "SpawnMarker", TileDisplayCategory.PillSpawn, COL_PILLSPAWN, "SP");
        }

        public static Color32 GetCategoryColor(TileDisplayCategory cat)
        {
            switch (cat)
            {
                case TileDisplayCategory.Empty: return COL_EMPTY;
                case TileDisplayCategory.Grass: return COL_GRASS;
                case TileDisplayCategory.Path: return COL_PATH;
                case TileDisplayCategory.PathNoPill: return COL_PATH_NOPILL;
                case TileDisplayCategory.Corner: return COL_CORNER_PATH;
                case TileDisplayCategory.Stop: return COL_STOP;
                case TileDisplayCategory.CrateDeliver: return COL_CRATE;
                case TileDisplayCategory.Tunnel: return COL_TUNNEL_A;
                case TileDisplayCategory.Arrow: return COL_ARROW;
                case TileDisplayCategory.FixedArrow: return COL_FIXED_ARROW;
                case TileDisplayCategory.Bridge: return COL_BRIDGE;
                case TileDisplayCategory.SwitchBridge: return COL_SWITCH_BRIDGE;
                case TileDisplayCategory.Turnout: return COL_TURNOUT;
                case TileDisplayCategory.DestructibleWall: return COL_DEST_WALL;
                case TileDisplayCategory.RoadBlock: return COL_ROADBLOCK;
                case TileDisplayCategory.RisingBlock: return COL_RISING;
                case TileDisplayCategory.Switch: return COL_SWITCH;
                case TileDisplayCategory.PlayerStart: return COL_PLAYER;
                case TileDisplayCategory.PillSpawn: return COL_PILLSPAWN;
                case TileDisplayCategory.SecretCollectible: return COL_SECRET;
                default: return COL_UNKNOWN;
            }
        }
    }
}
