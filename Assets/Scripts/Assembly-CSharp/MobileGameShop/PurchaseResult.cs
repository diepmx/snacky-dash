namespace MobileGameShop
{
	public struct PurchaseResult
	{
		public bool Success;

		public string ProductId;

		public string Error;

		public string Receipt;

		public static PurchaseResult Ok(string productId, string receipt = null)
		{
			return default(PurchaseResult);
		}

		public static PurchaseResult Fail(string productId, string error)
		{
			return default(PurchaseResult);
		}
	}
}
