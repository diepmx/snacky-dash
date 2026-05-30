using System;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

public class TriggerTutoZone : MonoBehaviour
{
	public static Action<BoosterId> OnTriggerBoosterTutoZone;

	public BoosterId boosterType;

	public bool destroyOnExit;

	private void OnTriggerEnter2D(Collider2D other)
	{
	}

	private void OnTriggerExit2D(Collider2D other)
	{
	}
}
