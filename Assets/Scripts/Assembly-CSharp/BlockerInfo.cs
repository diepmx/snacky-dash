using System;
using JuicedUp.Features.Core;
using UnityEngine;

[Serializable]
public struct BlockerInfo
{
	public BlockerKind kind;

	public int tailIndex;

	public Vector3Int cell;

	public Vector3 worldPos;

	public State state;

	public DirectionPlayer dir;
}
