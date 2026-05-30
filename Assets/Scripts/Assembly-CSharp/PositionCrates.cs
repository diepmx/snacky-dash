using System.Collections.Generic;
using UnityEngine;

public class PositionCrates : MonoBehaviour
{
	public int positionCrateIndex;

	public ExitDirection exitDirection;

	public Transform spawnPoint;

	public Transform activePoint;

	public Transform exitPoint;

	[Header("Waypoints Spawn -> Active (spawn/active not included)")]
	public List<LaneWaypoint> spawnToActive;

	[Header("Waypoints Active -> Exit ( active/exit not included)")]
	public List<LaneWaypoint> activeToExit;

	public LaneWaypoint SpawnNode => null;

	public LaneWaypoint ActiveNode => null;

	public LaneWaypoint ExitNode => null;
}
