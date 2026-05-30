using System;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class ManualCrateSetup
	{
		[FormerlySerializedAs("color")]
		public PillKind pillKind;

		public int requiredCount;
	}
}
