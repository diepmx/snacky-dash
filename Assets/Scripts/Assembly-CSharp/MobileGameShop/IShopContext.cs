namespace MobileGameShop
{
	public interface IShopContext
	{
		IEntitlementsService Entitlements { get; }

		IPurchaseHistoryService Purchases { get; }

		IWalletService Wallet { get; }

		IInventoryService Inventory { get; }

		ITimedBoostsService Boosts { get; }

		IPlayerProgressService PlayerProgress { get; }

		ITimeProvider Time { get; }
	}
}
