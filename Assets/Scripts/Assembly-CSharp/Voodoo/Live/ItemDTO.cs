using System.Collections.Generic;

namespace Voodoo.Live
{
	public sealed class ItemDTO
	{
		public string id;

		public string name;

		public List<string> tags;

		public bool IsValid => false;
	}
}
