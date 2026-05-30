using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Features.Shop.Internal.Data;

namespace JuicedUp.Features.Shop.Internal.Repositories
{
	internal class ShopRepository : IShopRepository
	{
		private readonly IDataRepository<ShopSaveData> _dataRepository;

		public bool IsStarterPackPurchased
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ShopRepository(IDataRepository<ShopSaveData> dataRepository)
		{
		}
	}
}
