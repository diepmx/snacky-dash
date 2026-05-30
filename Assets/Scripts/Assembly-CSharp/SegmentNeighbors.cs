using System;
using UnityEngine;

[Serializable]
public struct SegmentNeighbors
{
	public bool found;

	public int index;

	public Vector3Int cell;

	public bool hasPrev;

	public int prevIndex;

	public Vector3Int prevCell;

	public bool hasNext;

	public int nextIndex;

	public Vector3Int nextCell;

	public Vector3Int dirToPrev;

	public Vector3Int dirToNext;
}
