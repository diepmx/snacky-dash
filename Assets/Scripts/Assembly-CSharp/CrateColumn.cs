using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CrateColumn
{
	public List<CrateData> crates;

	[HideInInspector]
	public CrateData activeCrate;

	[HideInInspector]
	public Vector3 basePos;

	[HideInInspector]
	public PositionCrates lane;

	public Queue<CrateData> queue;
}
