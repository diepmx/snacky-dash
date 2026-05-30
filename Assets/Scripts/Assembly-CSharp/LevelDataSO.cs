using System.Collections.Generic;
using EasyButtons;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.BoardAlgorithm;
using JuicedUp.Features.Core.Ingredients;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "JuiceUp/Level Data", order = 0)]
public class LevelDataSO : ScriptableObject
{
	public static readonly int[] ValidCrateCounts;

	[Header("LDF tutorial onboarding (metadata, not tile gameplay)")]
	[Tooltip("Whether this level should show a first-loop one-shot LDF tutorial popup.")]
	public bool hasLdfTutorialForThisLevel;

	[Tooltip("Which ingredient mechanic this level introduces when the LDF tutorial flag is enabled.")]
	public IngredientType ldfTutorialIngredientType;

	[Header("Level Parameters")]
	public List<ManualColumnSetup> manualColumns;

	public int cratesTotal;

	public RespawnSequence respawnSequence;

	[Header("Special Mechanics")]
	[Tooltip("Number of crate completions required to lower a rising block after the player passes through it. Applied to every RisingBlockController in this level.")]
	public int risingBlockDeliveriesToLower;

	[Tooltip("Prefab levels / fallback: crate completions to destroy a wall when not using per-group list below.")]
	public int destructibleWallHealth;

	[Tooltip("Baked per destructible-wall group (JSON levels). Fingerprint must match current map or re-bake.")]
	public List<DestructibleWallGroupHealth> destructibleWallGroupHealths;

	[Tooltip("Topology hash of grouped path cells; editor compares to live JSON scan.")]
	public int destructibleWallGroupsFingerprint;

	[HideInInspector]
	public List<DebugColors> debug_Colors;

	[HideInInspector]
	public bool useLevelPrefab;

	[HideInInspector]
	public GameObject levelPrefab;

	public string LevelMapJsonData;

	[Header("Level source")]
	[field: SerializeField]
	public bool usingSeedRandom { get; private set; }

	[field: SerializeField]
	public int seedRandom { get; private set; }

	[field: SerializeField]
	public float speedPlayer { get; set; }

	[Header("Difficulty (used when no chunk/LevelMeta)")]
	[field: SerializeField]
	public LevelDifficulty difficulty { get; set; }

	[field: SerializeField]
	public int difficultyScore { get; set; }

	[Header("Board Algorithm")]
	[field: SerializeField]
	public WaveGenerationConfig boardAlgorithm { get; private set; }

	public string LevelMapJsonResourcePath => null;

	public bool HasLevelPrefab => false;

	public bool HasInlineMapJson => false;

	[Button("Check Total and debug colors")]
	public void CalculateAllTotals()
	{
	}

	[Button("Calculate Total")]
	private void CalculateTotal()
	{
	}

	private void UpdateDebugColors()
	{
	}
}
