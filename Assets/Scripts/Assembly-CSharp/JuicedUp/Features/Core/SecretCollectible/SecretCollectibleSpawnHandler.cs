using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	public class SecretCollectibleSpawnHandler : ISecretCollectibleSpawnHandler
	{
		private bool _useBoardAlgorithm;

		private float _secretSpawnChanceMin;

		private float _secretSpawnChanceMax;

		private List<HashSet<Vector2Int>> _secretCellsFromJson;

		private System.Random _random;

		private readonly Dictionary<int, float> _waveProbabilities;

		public void InitializeForLevel(bool useBoardAlgorithm, float secretSpawnChanceMin, float secretSpawnChanceMax, List<HashSet<Vector2Int>> secretCellsFromJson)
		{
		}

		public bool ShouldBeSecret(Vector3Int cell, int waveIndex, System.Random seededRandom = null)
		{
			return false;
		}

		private float RandomInRange(System.Random seededRandom, float min, float max)
		{
			return 0f;
		}
	}
}
