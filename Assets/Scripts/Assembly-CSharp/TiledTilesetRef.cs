using System;
using Newtonsoft.Json;

[Serializable]
public class TiledTilesetRef
{
	[JsonProperty("firstgid")]
	public int TileMapStartIndex { get; set; }

	[JsonProperty("source")]
	public string Source { get; set; }
}
