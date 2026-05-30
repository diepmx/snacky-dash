using System;
using JuicedUp.Features.Core;
using UnityEngine;

[Serializable]
public struct CellOccupancyInfo
{
	public Vector3Int cell;

	public bool hasHead;

	public int tailCount;

	public SnakeOccupant occupant;

	public TileType tileType;

	public bool hasTail => false;
}
