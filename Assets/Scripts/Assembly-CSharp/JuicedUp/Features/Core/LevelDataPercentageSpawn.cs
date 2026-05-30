using System;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class LevelDataPercentageSpawn
	{
		[FormerlySerializedAs("pillColor")]
		public PillKind pillKind;

		public float percentage;
	}
}
