using System;
using JuicedUp.Features.Core;
using UnityEngine.Serialization;

[Serializable]
public class ColorPlacementDebug
{
	[FormerlySerializedAs("color")]
	public PillKind pillKind;

	public int requested;

	public int placed;

	public int placedByFullGroups;

	public int placedBySingles;
}
