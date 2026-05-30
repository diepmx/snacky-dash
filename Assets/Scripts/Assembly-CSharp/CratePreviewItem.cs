using System;
using JuicedUp.Features.Core;
using UnityEngine.Serialization;

[Serializable]
public struct CratePreviewItem
{
	[FormerlySerializedAs("color")]
	public PillKind pillKind;

	public int boxCount;
}
