using System;

namespace Voodoo.Sauce.Internal.Analytics
{
	[Serializable]
	public struct ItemTransactionInfo
	{
		public string itemName;

		public ItemType itemType;

		public ItemTransactionInfo(string name, ItemType type)
		{
			itemName = null;
			itemType = default(ItemType);
		}

		public ItemTransactionInfo(Enum name, ItemType type)
		{
			itemName = null;
			itemType = default(ItemType);
		}
	}
}
