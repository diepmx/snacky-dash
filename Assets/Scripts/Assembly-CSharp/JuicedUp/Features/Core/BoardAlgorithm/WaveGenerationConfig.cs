using System;
using UnityEngine;

namespace JuicedUp.Features.Core.BoardAlgorithm
{
	[Serializable]
	public class WaveGenerationConfig
	{
		public bool enabled;

		[Min(2f)]
		public int waveCount;

		[Range(0.1f, 1f)]
		public float densityMin;

		[Range(0.1f, 1f)]
		public float densityMax;

		[Range(0f, 0.5f)]
		public float waveModifier;

		[Range(0f, 1f)]
		public float safetyFloor;

		[Range(0f, 1f)]
		public float secretSpawnChanceMin;

		[Range(0f, 1f)]
		public float secretSpawnChanceMax;

		public void Validate()
		{
		}

		public WaveGenerationConfig Clone()
		{
			return null;
		}
	}
}
