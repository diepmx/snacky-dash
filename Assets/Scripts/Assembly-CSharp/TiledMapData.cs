using System;
using Newtonsoft.Json;

[Serializable]
public class TiledMapData
{
	[JsonProperty("compressionlevel")]
	public int CompressionLevel { get; set; }

	[JsonProperty("height")]
	public int Height { get; set; }

	[JsonProperty("infinite")]
	public bool Infinite { get; set; }

	[JsonProperty("layers")]
	public TiledLayer[] Layers { get; set; }

	[JsonProperty("nextlayerid")]
	public int NextLayerId { get; set; }

	[JsonProperty("nextobjectid")]
	public int NextObjectId { get; set; }

	[JsonProperty("orientation")]
	public string Orientation { get; set; }

	[JsonProperty("renderorder")]
	public string RenderOrder { get; set; }

	[JsonProperty("tiledversion")]
	public string TiledVersion { get; set; }

	[JsonProperty("tileheight")]
	public int TileHeight { get; set; }

	[JsonProperty("tilesets")]
	public TiledTilesetRef[] Tilesets { get; set; }

	[JsonProperty("tilewidth")]
	public int TileWidth { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("version")]
	public string Version { get; set; }

	[JsonProperty("width")]
	public int Width { get; set; }
}
