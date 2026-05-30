using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New TileSet", menuName = "Tilemap/TileSet")]
public class TileSet : ScriptableObject
{
	[Serializable]
	public class NamedTile
	{
		public string tileName;

		public Tile tile;
	}

	public List<NamedTile> tiles;

	public Tile GetTileByName(string name)
	{
		return null;
	}
}
