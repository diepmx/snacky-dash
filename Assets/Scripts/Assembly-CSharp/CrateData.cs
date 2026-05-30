using System;
using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CrateData
{
	[FormerlySerializedAs("color")]
	public PillKind pillKind;

	public int requiredCount;

	public int remainingValue;

	[HideInInspector]
	public int currentCount;

	[HideInInspector]
	public bool isCompleted;

	[HideInInspector]
	public bool isReady;

	[HideInInspector]
	public HashSet<int> closedLids;

	[HideInInspector]
	public GameObject crateObject;

	public bool finishInProgress;

	public Crate crateScript;

	[HideInInspector]
	public CrateSpeechBubbleView speechBubbleView;

	[HideInInspector]
	public CrateFeedbackView feedbackView;

	[HideInInspector]
	public int visualStackCount;

	public ExitDirection exitDirection;
}
