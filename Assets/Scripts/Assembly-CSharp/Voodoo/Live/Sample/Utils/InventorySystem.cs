using System;
using System.Collections.Generic;

namespace Voodoo.Live.Sample.Utils
{
	public static class InventorySystem
	{
		private static Dictionary<string, int> _inventory;

		public static Action<string, int> OnItemUpdated;

		private const string INVENTORY_KEYS = "InventoryKeys";

		static InventorySystem()
		{
		}

		public static void AddItem(string itemName, int amount)
		{
		}

		public static bool RemoveItem(string itemName, int amount)
		{
			return false;
		}

		public static int GetItemAmount(string itemName)
		{
			return 0;
		}

		public static bool ContainsItem(string itemName)
		{
			return false;
		}

		public static void ClearInventory()
		{
		}

		private static void SaveInventory()
		{
		}

		private static void LoadInventory()
		{
		}
	}
}
