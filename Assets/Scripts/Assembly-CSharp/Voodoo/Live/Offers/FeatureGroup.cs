using System;
using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public abstract class FeatureGroup : Feature, IFeatureGroup, IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable
	{
		public IServerFeature dataTransferObject;

		private Product _selectedProduct;

		public List<Product> Products { get; set; }

		public Product SelectedProduct
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void Initialize()
		{
		}

		public override void Validate()
		{
		}

		protected virtual void OnStatusChanged(string status, IFeature feature)
		{
		}

		public override void Purchase()
		{
		}

		protected override void OnTransactionCompleted(Transaction transaction, bool succeed)
		{
		}

		public override Dictionary<string, object> GetContextParameters()
		{
			return null;
		}

		public override void Dispose()
		{
		}

		public override void Reset()
		{
		}
	}
}
