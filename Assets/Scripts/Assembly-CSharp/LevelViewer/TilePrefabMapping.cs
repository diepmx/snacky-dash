using System.Collections.Generic;

namespace LevelViewer
{
    public class TilePrefabInfo
    {
        public string Name;
        public string CoverPrefabPath; // Resources path (no extension)

        public TilePrefabInfo(string name, string coverPath)
        {
            Name = name;
            CoverPrefabPath = coverPath;
        }
    }

    /// <summary>
    /// Maps Tiled IDs to cover prefab resource paths.
    /// Built from TileDefinitionDatabase.asset.
    /// </summary>
    public static class TilePrefabMapping
    {
        private static Dictionary<int, TilePrefabInfo> _mapping;

        public static TilePrefabInfo Get(int tiledId)
        {
            if (_mapping == null) Build();
            if (_mapping.TryGetValue(tiledId, out var info)) return info;
            return new TilePrefabInfo($"Unknown_{tiledId}", null);
        }

        private static void Add(int id, string name, string coverPath)
        {
            _mapping[id] = new TilePrefabInfo(name, coverPath);
        }

        private static void Build()
        {
            _mapping = new Dictionary<int, TilePrefabInfo>();

            // === GRASS TILES ===
            Add(322, "Border_D",           "tilescovers/TileCov_Border_D");
            Add(323, "Border_L",           "tilescovers/TileCov_Border_L");
            Add(324, "Border_R",           "tilescovers/TileCov_Border_R");
            Add(325, "Border_U",           "tilescovers/TileCov_Border_U");
            Add(326, "CornerExt_LD",       "tilescovers/TileCov_CornerExt_LD");
            Add(327, "CornerExt_LU",       "tilescovers/TileCov_CornerExt_LU");
            Add(328, "CornerExt_RD",       "tilescovers/TileCov_CornerExt_RD");
            Add(329, "CornerExt_RU",       "tilescovers/TileCov_CornerExt_RU");
            Add(330, "CornerInt_LD_noP",   "tilescovers/TileCov_CornerInt_LD_noPath");
            Add(331, "CornerInt_LD",       "tilescovers/TileCov_CornerInt_LD");
            Add(332, "CornerInt_LU_noP",   "tilescovers/TileCov_CornerInt_LU_noPath");
            Add(333, "CornerInt_LU",       "tilescovers/TileCov_CornerInt_LU");
            Add(334, "CornerInt_RD_noP",   "tilescovers/TileCov_CornerInt_RD_noPath");
            Add(335, "CornerInt_RD",       "tilescovers/TileCov_CornerInt_RD");
            Add(336, "CornerInt_RU_noP",   "tilescovers/TileCov_CornerInt_RU_noPath");
            Add(337, "CornerInt_RU",       "tilescovers/TileCov_CornerInt_RU");
            Add(338, "Island_End_D",       "tilescovers/TileCov_Island_End_D");
            Add(339, "Island_End_L",       "tilescovers/TileCov_Island_End_L");
            Add(340, "Island_End_R",       "tilescovers/TileCov_Island_End_R");
            Add(341, "Island_End_U",       "tilescovers/TileCov_Island_End_U");
            Add(342, "Island_FlatTop",     "tilescovers/TileCov_Island_FlatTop");
            Add(343, "Island_Mid_LR",      "tilescovers/TileCov_Island_Mid_LR");
            Add(344, "Island_Mid_UD",      "tilescovers/TileCov_Island_Mid_UD");
            Add(345, "Island_Single",      "tilescovers/TileCov_Island_Single");

            // === PATH TILES ===
            Add(347, "Path_Cross",         "tilescovers/TILECOV_Path_Cross");
            Add(349, "Path_RL_NoPill",     "tilescovers/TILECOV_Path_LR_noPill");
            Add(350, "Path_RL",            "tilescovers/TILECOV_Path_LR");
            Add(351, "Path_UD_NoPill",     "tilescovers/TILECOV_Path_UD_NoPill");
            Add(352, "Path_UD",            "tilescovers/TILECOV_Path_UD");
            Add(353, "Path_CrossR",        "tilescovers/TILECOV_Path_CrossR");
            Add(354, "Path_CrossU",        "tilescovers/TILECOV_Path_CrossU");
            Add(355, "Path_CrossD",        "tilescovers/TILECOV_Path_CrossD");
            Add(356, "Path_CrossL",        "tilescovers/TILECOV_Path_CrossL");

            // === CORNER PATH (using path corner prefabs) ===
            // CornerInt tiles with paths use dedicated corner prefabs
            // The tileDb doesn't list explicit corners; the game infers them from CornerInt tiles

            // === STOP ===
            Add(294, "Stop",               "gridtile/Stop_Visual");

            // === CRATE DELIVERY ===
            Add(295, "CrateDeliver_0",     "tilescovers/TILECOV_CRATE_DELIVERY");
            Add(296, "CrateDeliver_1",     "tilescovers/TILECOV_CRATE_DELIVERY");
            Add(297, "CrateDeliver_2",     "tilescovers/TILECOV_CRATE_DELIVERY");

            // === TUNNEL ===
            Add(278, "Tunnel_Left_A",      "tilescovers/TILECOV_INGREDIENT_Tunnel_A");
            Add(279, "Tunnel_Up_A",        "tilescovers/TILECOV_INGREDIENT_Tunnel_A");
            Add(280, "Tunnel_Right_A",     "tilescovers/TILECOV_INGREDIENT_Tunnel_A");
            Add(281, "Tunnel_Down_A",      "tilescovers/TILECOV_INGREDIENT_Tunnel_A");
            Add(360, "Tunnel_Down_B",      "tilescovers/TILECOV_INGREDIENT_Tunnel_B");
            Add(361, "Tunnel_Left_B",      "tilescovers/TILECOV_INGREDIENT_Tunnel_B");
            Add(362, "Tunnel_Right_B",     "tilescovers/TILECOV_INGREDIENT_Tunnel_B");
            Add(363, "Tunnel_Up_B",        "tilescovers/TILECOV_INGREDIENT_Tunnel_B");
            Add(384, "Tunnel_Down_C",      "tilescovers/TILECOV_INGREDIENT_Tunnel_C");
            Add(385, "Tunnel_Left_C",      "tilescovers/TILECOV_INGREDIENT_Tunnel_C");
            Add(386, "Tunnel_Right_C",     "tilescovers/TILECOV_INGREDIENT_Tunnel_C");
            Add(382, "Tunnel_Up_C",        "tilescovers/TILECOV_INGREDIENT_Tunnel_C");
            Add(380, "Tunnel_Down_D",      "tilescovers/TILECOV_INGREDIENT_Tunnel_D");
            Add(379, "Tunnel_Left_D",      "tilescovers/TILECOV_INGREDIENT_Tunnel_D");
            Add(381, "Tunnel_Right_D",     "tilescovers/TILECOV_INGREDIENT_Tunnel_D");
            Add(378, "Tunnel_Up_D",        "tilescovers/TILECOV_INGREDIENT_Tunnel_D");

            // === ARROWS - Flipping ===
            Add(303, "Arrow_Left",         "tilescovers/TILECOV_INGREDIENT_ArrowLeft");
            Add(301, "Arrow_Left_1",       "tilescovers/TILECOV_INGREDIENT_ArrowLeft");
            Add(306, "Arrow_Right",        "tilescovers/TILECOV_INGREDIENT_ArrowRight");
            Add(304, "Arrow_Right_1",      "tilescovers/TILECOV_INGREDIENT_ArrowRight");
            Add(300, "Arrow_Down",         "tilescovers/TILECOV_INGREDIENT_ArrowDown");
            Add(298, "Arrow_Down_1",       "tilescovers/TILECOV_INGREDIENT_ArrowDown");
            Add(309, "Arrow_Up",           "tilescovers/TILECOV_INGREDIENT_ArrowUp");
            Add(307, "Arrow_Up_1",         "tilescovers/TILECOV_INGREDIENT_ArrowUp");

            // === ARROWS - Fixed ===
            Add(302, "FixedArrow_Left",    "tilescovers/TILECOV_INGREDIENT_ArrowLeft_Fixed");
            Add(305, "FixedArrow_Right",   "tilescovers/TILECOV_INGREDIENT_ArrowRight_Fixed");
            Add(299, "FixedArrow_Down",    "tilescovers/TILECOV_INGREDIENT_ArrowDown_Fixed");
            Add(308, "FixedArrow_Up",      "tilescovers/TILECOV_INGREDIENT_ArrowUp_Fixed");

            // === BRIDGE ===
            Add(357, "Bridge_UD",          "tilescovers/TILECOV_BRIDGE_UD");
            Add(359, "Bridge_LR",          "tilescovers/TILECOV_BRIDGE_LR");
            Add(358, "SwitchBridge_LR",    "tilescovers/TILECOV_BRIDGE_SWITCHING_LR");

            // === TURNOUT / AIGUILLAGE ===
            Add(320, "Turnout_Up_L",       "tilescovers/TILECOV_Path_Turnout_Left");
            Add(321, "Turnout_Up_R",       "tilescovers/TILECOV_Path_Turnout_Right");
            Add(318, "Turnout_UP_RL",      "tilescovers/TILECOV_Path_Turnout_UP_R_L");
            Add(317, "Turnout_UP_RL2",     "tilescovers/TILECOV_Path_Turnout_UP_R_Left");
            Add(311, "Turnout_DN_RL",      "tilescovers/TILECOV_Path_Turnout_DOWN_R_L");
            Add(312, "Turnout_DN_RL2",     "tilescovers/TILECOV_Path_Turnout_DOWN_R_Left");
            Add(313, "Turnout_L_UD",       "tilescovers/TILECOV_Path_Turnout_LEFT_U_D");
            Add(314, "Turnout_L_UD2",      "tilescovers/TILECOV_Path_Turnout_LEFT_U_Down");
            Add(316, "Turnout_R_UD",       "tilescovers/TILECOV_Path_Turnout_RIGHT_Up_D");
            Add(315, "Turnout_R_UD2",      "tilescovers/TILECOV_Path_Turnout_RIGHT_U_Down");

            // === DESTRUCTIBLE WALL ===
            Add(291, "DWall_V",            "ldfs/DestructibleWall_V");
            Add(283, "DWall_H",            "ldfs/DestructibleWall_H");

            // === ROAD BLOCK / RISING BLOCK ===
            Add(286, "RoadBlock",          "ldfs/RoadBlock");
            Add(285, "RisingBlock",        "ldfs/RisingBlock");

            // === SWITCH ===
            Add(290, "Switch",             "ldfs/SwitchUniversal");
            Add(292, "SwitchArc",          "gridtile/View_CrossRoad");
            Add(346, "CrossToggle",        "tilescovers/TILECOV_Path_Cross_Toggle");

            // === CONNECTION ===
            Add(319, "Connection",         "tilescovers/TILECOV_CONNECTION");
            Add(387, "DeliveryEnd",        "tilescovers/TILECOV_CONNECTION_END");

            // === PLAYER START / PILLS / MISC ===
            // These don't have cover prefabs, will use fallback colored quads
            Add(287, "PlayerStart",        null);
            Add(288, "PlayerStart2",       null);
            Add(277, "PillSpawn",          null);
            Add(372, "PillSpawn1",         null);
            Add(373, "PillSpawn2",         null);
            Add(276, "NoPillSpawn",        null);
            Add(282, "SpawnMarker",        null);
            Add(389, "SecretCollectible",  null);
            Add(388, "Cross_Start",        null);
            Add(348, "Cross_Special",      null);
        }
    }
}
