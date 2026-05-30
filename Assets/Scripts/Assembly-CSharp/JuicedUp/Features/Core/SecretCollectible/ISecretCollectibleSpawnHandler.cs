using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core.SecretCollectible
{
	public interface ISecretCollectibleSpawnHandler
	{
		void InitializeForLevel(bool useBoardAlgorithm, float secretSpawnChanceMin, float secretSpawnChanceMax, List<HashSet<Vector2Int>> secretCellsFromJson);

		bool ShouldBeSecret(Vector3Int cell, int waveIndex, System.Random seededRandom = null);
	}
}
