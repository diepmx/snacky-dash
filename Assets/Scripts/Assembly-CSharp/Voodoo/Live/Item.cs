using Newtonsoft.Json;
using UnityEngine;

namespace Voodoo.Live
{
	public class Item : IResultProvider
	{
		private ItemDTO _dto;

		public Result Validation { get; private set; }

		public string Id => null;

		public string Name => null;

		public string[] Tags => null;

		[JsonIgnore]
		public Sprite sprite { get; set; }

		public Item(ItemDTO dto)
		{
		}

		public void Validate()
		{
		}
	}
}
