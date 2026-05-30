using System;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core;
using UnityEngine;

public class Trigger_Hint : MonoBehaviour
{
	public static Action<BoosterId> OnTriggeringHint;

	public BoosterId boosterType;

	public bool collisionBasedTrigger;

	public int snakeLengthRequired;

	private bool alreadyTriggered;

	private TailManager playerTail;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
	}
}
