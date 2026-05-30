namespace Voodoo.Live.Analytics.Shop
{
	public interface IShopBlackboardFiller
	{
		void Fill(IBlackboard blackboard, ShopEventData data);

		void Fill(IBlackboard blackboard, ProductShopEventData data);

		void Fill(IBlackboard blackboard, ShopSourceEventData data);

		void Fill(IBlackboard blackboard, TransactionReceipt receipt);
	}
}
