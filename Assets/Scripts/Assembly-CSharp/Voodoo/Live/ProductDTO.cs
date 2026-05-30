using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace Voodoo.Live
{
	public sealed class ProductDTO
	{
		public string id;

		public string title;

		public RewardDTO reward;

		public PriceDTO price;

		public ConditionsDTO conditions;

		public List<string> tags;

		[JsonExtensionData]
		private IDictionary<string, JToken> _additionalData;

		public string type { get; set; }

		public bool IsValid => false;

		[Preserve]
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
