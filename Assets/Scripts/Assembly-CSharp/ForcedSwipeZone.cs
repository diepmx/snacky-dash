using System;
using JuicedUp.Features.Core;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ForcedSwipeZone : MonoBehaviour
{
	public static Action<SwipeController.DirMask> OnForceSwipeZoneDirection;

	public static Action OnForceSwipeZoneLeft;

	[Header("Allowed directions while inside")]
	public SwipeController.DirMask allowed;

	[Header("Tuto behavior")]
	public bool destroyOnExit;

	private int _insideCount;

	private bool gameStarted;

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
	}

	private void OnTriggerExit2D(Collider2D other)
	{
	}

	private void OnSpawnPlayer()
	{
	}
}
