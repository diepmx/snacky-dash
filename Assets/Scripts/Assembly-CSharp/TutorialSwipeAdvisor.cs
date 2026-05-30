using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public class TutorialSwipeAdvisor : MonoBehaviour
{
	public HandAnimation handAnimation;

	[Header("Options")]
	[SerializeField]
	private bool avoidBacktracking;

	[SerializeField]
	private bool onlyAtIntersections;

	private readonly bool onlyUnlockedGroups;

	private bool _isAtDeliveryPoint;

	[Header("Refs")]
	private PillManager pillManager;

	private CrateManager crateManager;

	private Player player;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnArrivedAtCrate(int crateIndex)
	{
	}

	private void OnLeftCrate()
	{
	}

	private void OnArrivedAtDestination()
	{
	}

	private DirectionPlayer GetBestDirection(List<DirectionPlayer> allowedDirs, DirectionPlayer comeFrom)
	{
		return default(DirectionPlayer);
	}

	private float DistanceToNearestActivePillSqr(Vector3 fromWorld)
	{
		return 0f;
	}

	private bool TryGetNearestActivePill(Vector3 originWorld, out Vector3 nearestPos)
	{
		nearestPos = default(Vector3);
		return false;
	}

	private DirectionPlayer GetDirectionTowardNearestCrate(List<DirectionPlayer> allowedDirs, DirectionPlayer comeFrom)
	{
		return default(DirectionPlayer);
	}

	private float DistanceToNearestCrateSqr(Vector3 fromWorld)
	{
		return 0f;
	}
}
