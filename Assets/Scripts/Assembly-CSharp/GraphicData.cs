using System;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class GraphicData
{
	[FormerlySerializedAs("pillColor")]
	public PillKind pillKind;

	public Material materialCrate;

	public Material materialPillInSnake;
}
