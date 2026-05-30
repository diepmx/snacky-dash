using System;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core;
using UnityEngine;

public class Booster : MonoBehaviour
{
	public static Action<BoosterId> OnBoosterClicked;

	public BoosterId powerUpType;

	private SwipeController swipeController;

	private void Start()
	{
	}

	public void ClickBooster()
	{
	}
}
