using System;
using Newtonsoft.Json;

[Serializable]
public class TiledLayer
{
	private const uint FlipMask = 4026531840u;

	[JsonProperty("data")]
	public uint[] Data { get; set; }

	[JsonProperty("height")]
	public int Height { get; set; }

	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("opacity")]
	public float Opacity { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("visible")]
	public bool Visible { get; set; }

	[JsonProperty("width")]
	public int Width { get; set; }

	[JsonProperty("x")]
	public int X { get; set; }

	[JsonProperty("y")]
	public int Y { get; set; }

	public static uint StripFlipFlags(uint gid)
	{
		return gid & ~FlipMask;
	}
}
