namespace MobileGameShop
{
	public class PlayerPrefsPurchaseHistoryService : IPurchaseHistoryService
	{
		private const string Prefix = "MGS_PUR_";

		public bool HasPurchased(string offerOrProductId)
		{
			return false;
		}

		public void MarkPurchased(string offerOrProductId)
		{
		}
	}
}
