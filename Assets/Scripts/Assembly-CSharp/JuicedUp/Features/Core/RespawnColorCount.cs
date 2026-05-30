using System;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class RespawnColorCount
	{
		[FormerlySerializedAs("color")]
		public PillKind pillKind;

		public int count;
	}
}
