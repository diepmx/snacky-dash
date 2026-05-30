using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTracker : MonoBehaviour
{
	public Tilemap tilemap;

	public GameObject prefabTestFill;

	private readonly HashSet<Vector3Int> visitedTiles;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void MarkVisited(Vector3Int gridPosition)
	{
	}

	private void OnArrivedAtDestinationListener()
	{
	}

	private bool IsTileVisited(Vector3Int position)
	{
		return false;
	}

	private bool IsValidTile(Vector3Int position)
	{
		return false;
	}

	private List<Vector3Int> GetEnclosedTiles()
	{
		return null;
	}

	private List<Vector3Int> GetUnvisitedTiles(HashSet<Vector3Int> outsideTiles)
	{
		return null;
	}

	private HashSet<Vector3Int> FloodFillFrom(Vector3Int startCell)
	{
		return null;
	}
}
