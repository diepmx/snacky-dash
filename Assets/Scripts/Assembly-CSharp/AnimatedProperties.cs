using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class AnimatedProperties
{
	public AnimationType AnimationType;

	public Ease EaseType;

	public int LoopCount;

	public float LoopDelay;

	public LoopType LoopType;

	[Header("Start")]
	[DrawIf("AnimationType", AnimationType.Position, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 positionStart;

	[DrawIf("AnimationType", AnimationType.Scale, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 scaleStart;

	[DrawIf("AnimationType", AnimationType.Rotate, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 startRotation;

	[DrawIf("AnimationType", AnimationType.Fade, DrawIfAttribute.DisablingType.DontDraw)]
	public float fadeStart;

	[DrawIf("AnimationType", AnimationType.PunchScale, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchScaleStart;

	[DrawIf("AnimationType", AnimationType.PunchPosition, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchPositionStart;

	[DrawIf("AnimationType", AnimationType.PunchRotation, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchRotationStart;

	[Header("End")]
	[DrawIf("AnimationType", AnimationType.Scale, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 scaleEnd;

	[DrawIf("AnimationType", AnimationType.Position, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 positionEnd;

	[DrawIf("AnimationType", AnimationType.Fade, DrawIfAttribute.DisablingType.DontDraw)]
	public float fadeEnd;

	[DrawIf("AnimationType", AnimationType.Rotate, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 endRotation;

	[DrawIf("AnimationType", AnimationType.PunchScale, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchScaleEnd;

	[DrawIf("AnimationType", AnimationType.PunchPosition, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchPositionEnd;

	[DrawIf("AnimationType", AnimationType.PunchRotation, DrawIfAttribute.DisablingType.DontDraw)]
	public Vector3 punchRotationEnd;

	[Header("Extra Settings")]
	[DrawIf("AnimationType", AnimationType.Rotate, DrawIfAttribute.DisablingType.DontDraw)]
	public bool useShortestRotation;

	[DrawIf("AnimationType", AnimationType.PunchScale, DrawIfAttribute.DisablingType.DontDraw)]
	public float punchScaleElasticity;

	[DrawIf("AnimationType", AnimationType.PunchScale, DrawIfAttribute.DisablingType.DontDraw)]
	public int punchScaleVibration;

	[DrawIf("AnimationType", AnimationType.PunchRotation, DrawIfAttribute.DisablingType.DontDraw)]
	public float punchRotationElasticity;

	[DrawIf("AnimationType", AnimationType.PunchRotation, DrawIfAttribute.DisablingType.DontDraw)]
	public int punchRotationVibration;

	[DrawIf("AnimationType", AnimationType.PunchPosition, DrawIfAttribute.DisablingType.DontDraw)]
	public float punchPositionElasticity;

	[DrawIf("AnimationType", AnimationType.PunchPosition, DrawIfAttribute.DisablingType.DontDraw)]
	public int punchPositionVibration;
}
