using System;
using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	[Serializable]
	public class NonConsumableProductToItems
	{
		public Dictionary<string, string[]> ios;

		public Dictionary<string, string[]> android;
	}
}
