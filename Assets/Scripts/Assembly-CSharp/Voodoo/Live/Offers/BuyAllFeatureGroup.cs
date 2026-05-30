using System;
using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public abstract class BuyAllFeatureGroup : FeatureGroup, IBuyAllFeatureGroup, IFeatureGroup, IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable
	{
		public const string BuyAllSetPurchaseId = "BuyAll";

		private IPrice _buyAllPrice;

		private Reward _combinedReward;

		private bool _buyAllOnGoing;

		public bool IsBuyAllTransaction => false;

		public IPrice BuyAllPrice => null;

		public IReward BuyAllReward => null;

		public override void Validate()
		{
		}

		public void SetBuyAllPrice(IPrice price)
		{
		}

		public Transaction PurchaseAll()
		{
			return null;
		}

		protected override void OnTransactionCompleted(Transaction transaction, bool succeed)
		{
		}

		protected Reward CombineProductRewards()
		{
			return null;
		}

		public override Dictionary<string, object> GetContextParameters()
		{
			return null;
		}
	}
}
