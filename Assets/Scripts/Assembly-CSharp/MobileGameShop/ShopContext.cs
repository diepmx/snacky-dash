namespace MobileGameShop
{
	public class ShopContext : IShopContext
	{
		public IEntitlementsService Entitlements { get; }

		public IPurchaseHistoryService Purchases { get; }

		public IWalletService Wallet { get; }

		public IInventoryService Inventory { get; }

		public ITimedBoostsService Boosts { get; }

		public IPlayerProgressService PlayerProgress { get; }

		public ITimeProvider Time { get; }

		public ShopContext(IEntitlementsService entitlements, IPurchaseHistoryService purchases, IWalletService wallet, IInventoryService inventory, ITimedBoostsService boosts, IPlayerProgressService playerProgress, ITimeProvider time)
		{
		}
	}
}
