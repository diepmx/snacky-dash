using System;
using UnityEngine;

[Serializable]
public class LaneWaypoint
{
	public Transform point;

	public Quaternion Rot => default(Quaternion);
}
