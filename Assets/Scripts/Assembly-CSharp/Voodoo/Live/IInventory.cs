using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IInventory
	{
		Item GetItemById(string id);

		bool HasItem(string id);

		bool HasItemQuantity(string itemId, int amount);

		bool IsItemOwned(string itemId);

		bool ApplyItemDelta(string itemId, int delta);

		Item GetItemByName(string name);

		bool HasItemByName(string name);

		bool HasItemQuantityByName(string itemName, int amount);

		bool IsItemOwnedByName(string itemName);

		void ApplyItemDeltaByName(string itemName, int delta);

		Product CreateProduct(ProductDTO productDTO, string context = null);

		IReward CreateReward(RewardDTO dto, string context = null);

		IPrice CreatePrice(PriceDTO priceDTO, string context = null);

		ItemQuantity CreateItemQuantity(ItemQuantityDTO dto, out string errorMessage);

		ItemQuantity[] CreateItemQuantities(ItemQuantityDTO[] dtos, out string error);

		void InitializeNonConsumableMapping(Dictionary<string, string[]> skuToItems);

		bool IsItemNonConsumable(string itemName);

		bool IsItemNonConsumable(Item item);

		bool IsPriceNonConsumable(IPrice price);

		string[] GetNonConsumableSkusByItemName(string itemName);

		string[] GetNonConsumableItemNamesBySku(string sku);

		bool HasNonConsumableItemPurchased(List<string> itemNames, out string itemName);

		bool TryRestoreNonConsumable(string sku);
	}
}
