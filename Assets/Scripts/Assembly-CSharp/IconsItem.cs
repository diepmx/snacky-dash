using System;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class IconsItem
{
	[FormerlySerializedAs("pillColor")]
	public PillKind pillKind;

	public Sprite sprite;

	public Sprite spriteNoOutline;
}
