using System;
using JuicedUp.Features.Core;
using UnityEngine;

[Serializable]
public struct TailUnderInfo
{
	public bool valid;

	public Vector3 worldPos;

	public Vector3Int cell;

	public TileType groundTileType;

	public SnakeOccupant snakeOccupant;

	public bool hasPill;

	public bool hasCover;
}
