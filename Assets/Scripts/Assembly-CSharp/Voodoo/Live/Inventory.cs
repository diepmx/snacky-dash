using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public class Inventory : IInventory
	{
		private readonly Dictionary<string, Item> _itemsById;

		private readonly Dictionary<string, Item> _itemsByName;

		private Func<string, int, bool> _hasItemQuantityFunc;

		private Func<string, int, bool> _applyItemDeltaFunc;

		private Dictionary<string, string[]> _skuToItems;

		private Dictionary<string, string[]> _itemToSkus;

		private readonly ConcurrentBag<string> _pendingSKURestoration;

		private bool _isNonConsumableInitialized;

		public void PopulateItems(Item[] items)
		{
		}

		public void Configure(Func<string, int, bool> hasItemQuantityFunc, Func<string, int, bool> applyItemDeltaFunc)
		{
		}

		public Item GetItemById(string id)
		{
			return null;
		}

		public bool HasItem(string id)
		{
			return false;
		}

		public bool IsItemOwned(string itemId)
		{
			return false;
		}

		public bool HasItemQuantity(string itemId, int amount)
		{
			return false;
		}

		public bool ApplyItemDelta(string itemId, int delta)
		{
			return false;
		}

		public Item GetItemByName(string name)
		{
			return null;
		}

		public bool HasItemByName(string name)
		{
			return false;
		}

		public bool IsItemOwnedByName(string itemName)
		{
			return false;
		}

		public bool HasItemQuantityByName(string itemName, int amount)
		{
			return false;
		}

		public void ApplyItemDeltaByName(string itemName, int delta)
		{
		}

		public Product CreateProduct(ProductDTO dto, string context = null)
		{
			return null;
		}

		public IReward CreateReward(RewardDTO dto, string context = null)
		{
			return null;
		}

		public IPrice CreatePrice(PriceDTO priceDTO, string context = null)
		{
			return null;
		}

		private Reward CreateStandardReward(RewardDTO dto)
		{
			return null;
		}

		private RandomReward CreateRandomReward(RewardDTO dto)
		{
			return null;
		}

		public ItemQuantity CreateItemQuantity(ItemQuantityDTO dto, out string errorMessage)
		{
			errorMessage = null;
			return null;
		}

		public ItemQuantity[] CreateItemQuantities(ItemQuantityDTO[] dtos, out string error)
		{
			error = null;
			return null;
		}

		public void InitializeNonConsumableMapping(Dictionary<string, string[]> skuToItems)
		{
		}

		public bool IsItemNonConsumable(string itemName)
		{
			return false;
		}

		public bool IsItemNonConsumable(Item item)
		{
			return false;
		}

		public bool IsPriceNonConsumable(IPrice price)
		{
			return false;
		}

		public string[] GetNonConsumableSkusByItemName(string itemName)
		{
			return null;
		}

		public string[] GetNonConsumableItemNamesBySku(string sku)
		{
			return null;
		}

		public bool HasNonConsumableItemPurchased(List<string> itemNames, out string itemName)
		{
			itemName = null;
			return false;
		}

		public bool TryRestoreNonConsumable(string sku)
		{
			return false;
		}
	}
}
