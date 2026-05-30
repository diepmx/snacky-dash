using Voodoo.Live.Analytics.Shop;
using Voodoo.Live.Analytics.Transaction;
using Voodoo.Live.Shop;

namespace Voodoo.Live.Analytics
{
	public class ShopEventsTracker
	{
		private readonly IBlackboard _blackboard;

		private readonly IShopEventDataFactory _dataFactory;

		private readonly IShopBlackboardFiller _filler;

		private readonly ShopProductShownEvent _shopProductShownEvent;

		private readonly ShopProductClickedEvent _shopProductClickedEvent;

		private readonly ShopOpenedEvent _shopOpenedEvent;

		private readonly ShopClosedEvent _shopClosedEvent;

		private readonly ShopOpenFailedEvent _shopOpenFailedEvent;

		private readonly ShopNonCashTransactionEvent _shopNonCashTransactionEvent;

		private readonly ShopNonCashTransactionEventFailed _shopNonCashTransactionEventFailed;

		public ShopEventsTracker(IBlackboard blackboard)
		{
		}

		public void TrackShopProductClicked(GameShop gameShop, Product product)
		{
		}

		public void TrackShopProductShown(GameShop gameShop, Product product)
		{
		}

		public void TrackShopOpened(GameShop gameShop)
		{
		}

		public void TrackShopClosed(GameShop gameShop)
		{
		}

		public void TrackShopOpenFailed(ShopSource source)
		{
		}

		public void TrackShopNonCashTransactionEvent(GameShop gameShop, Product product, TransactionReceipt receipt)
		{
		}

		public void TrackShopNonCashTransactionEventFailed(GameShop gameShop, Product product, TransactionReceipt receipt, string failureReason)
		{
		}
	}
}
