using System;
using System.Collections.Generic;

namespace Voodoo.Live.Shop
{
	public class ShopProduct : IPurchasable, IDisposable
	{
		private readonly Product _product;

		public Product Product => null;

		public GameShop GameShop { get; set; }

		public string Id => null;

		public string Name => null;

		public IPrice Price => null;

		public IReward Reward => null;

		public List<string> Tags => null;

		public ShopProduct(Product product)
		{
		}

		public bool CanUse(List<string> ignoreKeys = null)
		{
			return false;
		}

		public virtual void RecoverTransaction(Transaction transaction)
		{
		}

		public void Purchase()
		{
		}

		private void OnTransactionCompleted(Transaction transaction, bool success)
		{
		}

		public virtual Dictionary<string, object> GetContextParameters()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
