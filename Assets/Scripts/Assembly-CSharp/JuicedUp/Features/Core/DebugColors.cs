using System;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class DebugColors
	{
		[FormerlySerializedAs("color")]
		public PillKind pillKind;

		public int countInCrates;

		public int numberSpawned;
	}
}
