namespace MobileGameShop
{
	public interface IPurchaseHistoryService
	{
		bool HasPurchased(string offerOrProductId);

		void MarkPurchased(string offerOrProductId);
	}
}
