using System;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class LevelData : MonoBehaviour
	{
		public bool usingSeedRandom;

		public int seedRandom;

		public float speedPlayer;

		public bool isVideoChunk;

		[Header("Prefab Level Data")]
		[SerializeField]
		private Transform playerStartPosition;

		[Header("Level Parameters")]
		public List<ManualColumnSetup> manualColumns;

		[Header("Debug")]
		public int cratesTotal;

		public RespawnSequence respawnSequence;

		[Header("Debug")]
		[HideInInspector]
		public List<DebugColors> debug_Colors;

		[Header("USELESS")]
		public List<LevelDataPercentageSpawn> levelDataPercentageSpawns;

		public Transform PlayerStartPosition => null;

		[Button("Check Total and debug colors")]
		public void CalculateAllTotals()
		{
		}

		[Button("Calculate Total")]
		public void CalculateTotal()
		{
		}

		public void UpdateDebugColors()
		{
		}

		public PillKind GetRandomColorByPercentage(System.Random rng)
		{
			return default(PillKind);
		}

		public PillKind GetRandomColorByPercentage()
		{
			return default(PillKind);
		}
	}
}
