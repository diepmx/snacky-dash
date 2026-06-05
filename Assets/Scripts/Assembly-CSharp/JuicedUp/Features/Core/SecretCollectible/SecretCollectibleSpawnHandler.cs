using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	/// <summary>
	/// Determines whether a pill spawn cell should produce a Secret Collectible (Mystery Fruit)
	/// instead of a regular fruit.
	/// 
	/// Two modes:
	///   - Board Algorithm: use a random probability per wave (chanceMin–chanceMax range).
	///   - JSON cells: only allow secret spawn on cells explicitly listed in the level JSON data.
	/// </summary>
	public class SecretCollectibleSpawnHandler : ISecretCollectibleSpawnHandler
	{
		private bool _useBoardAlgorithm;
		private float _secretSpawnChanceMin;
		private float _secretSpawnChanceMax;
		private List<HashSet<Vector2Int>> _secretCellsFromJson;
		private System.Random _random;

		// Pre-computed probability per wave index (waveIndex → probability in [0,1])
		private readonly Dictionary<int, float> _waveProbabilities = new Dictionary<int, float>();

		// ─── Setup ───────────────────────────────────────────────────────────────

		/// <summary>
		/// Initialize spawn parameters for the current level.
		/// Call once per level before any ShouldBeSecret queries.
		/// </summary>
		public void InitializeForLevel(
			bool useBoardAlgorithm,
			float secretSpawnChanceMin,
			float secretSpawnChanceMax,
			List<HashSet<Vector2Int>> secretCellsFromJson)
		{
			_useBoardAlgorithm    = useBoardAlgorithm;
			_secretSpawnChanceMin = Mathf.Clamp01(secretSpawnChanceMin);
			_secretSpawnChanceMax = Mathf.Clamp01(secretSpawnChanceMax);
			_secretCellsFromJson  = secretCellsFromJson;
			_random               = new System.Random();
			_waveProbabilities.Clear();
		}

		// ─── Query ───────────────────────────────────────────────────────────────

		/// <summary>
		/// Returns true if the spawn at (cell, waveIndex) should be a Secret Collectible.
		/// </summary>
		public bool ShouldBeSecret(Vector3Int cell, int waveIndex, System.Random seededRandom = null)
		{
			if (_useBoardAlgorithm)
			{
				return ShouldBeSecretByProbability(waveIndex, seededRandom);
			}

			// JSON-driven mode: only spawn secret on explicitly listed cells
			return ShouldBeSecretByJsonCells(cell, waveIndex);
		}

		// ─── Private ─────────────────────────────────────────────────────────────

		private bool ShouldBeSecretByProbability(int waveIndex, System.Random seededRandom)
		{
			float probability = GetOrComputeWaveProbability(waveIndex, seededRandom);
			float roll = (float)RandomInRange(seededRandom ?? _random, 0.0, 1.0);
			return roll < probability;
		}

		private float GetOrComputeWaveProbability(int waveIndex, System.Random seededRandom)
		{
			if (_waveProbabilities.TryGetValue(waveIndex, out float cached))
				return cached;

			float probability = RandomInRange(seededRandom ?? _random,
				_secretSpawnChanceMin,
				_secretSpawnChanceMax);

			_waveProbabilities[waveIndex] = probability;
			return probability;
		}

		private bool ShouldBeSecretByJsonCells(Vector3Int cell, int waveIndex)
		{
			if (_secretCellsFromJson == null || waveIndex < 0 || waveIndex >= _secretCellsFromJson.Count)
				return false;

			HashSet<Vector2Int> waveCells = _secretCellsFromJson[waveIndex];
			if (waveCells == null) return false;

			return waveCells.Contains(new Vector2Int(cell.x, cell.y));
		}

		private float RandomInRange(System.Random seededRandom, float min, float max)
		{
			if (seededRandom != null)
				return (float)(seededRandom.NextDouble() * (max - min) + min);

			if (_random != null)
				return (float)(_random.NextDouble() * (max - min) + min);

			return UnityEngine.Random.Range(min, max);
		}

		// Overload that accepts double bounds for internal use
		private double RandomInRange(System.Random seededRandom, double min, double max)
		{
			if (seededRandom != null)
				return seededRandom.NextDouble() * (max - min) + min;
			if (_random != null)
				return _random.NextDouble() * (max - min) + min;
			return UnityEngine.Random.Range((float)min, (float)max);
		}
	}
}
