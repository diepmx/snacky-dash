using System;
using JuicedUp.Features.Core;
using UnityEngine;

[Serializable]
public struct PositionStateRotation
{
	public Vector3 position;

	public Quaternion rotation;

	public State state;

	public DirectionPlayer direction;

	public PositionStateRotation(Vector3 position, Quaternion rotation, State state, DirectionPlayer direction)
	{
		this.position = default(Vector3);
		this.rotation = default(Quaternion);
		this.state = default(State);
		this.direction = default(DirectionPlayer);
	}
}
