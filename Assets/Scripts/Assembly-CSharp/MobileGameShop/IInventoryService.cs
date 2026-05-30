namespace MobileGameShop
{
	public interface IInventoryService
	{
		void AddItem(string itemId, int amount);

		int GetCount(string itemId);
	}
}
