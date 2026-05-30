using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Converters;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Live;

namespace JuicedUp.Common.Economy.Internal.Converters
{
	internal class EconomyConverter : IEconomyConverter
	{
		public IEnumerable<JuicedUp.Common.Economy.Public.Data.IReward> ConvertToRewards(IEnumerable<ICost> costs)
		{
			return null;
		}

		public IEnumerable<JuicedUp.Common.Economy.Public.Data.IReward> ConvertToRewards(IEnumerable<ItemQuantityDTO> rewardItems)
		{
			return null;
		}

		public IEnumerable<IProduct> ConvertToProducts(IEnumerable<ProductDTO> productDtos)
		{
			return null;
		}

		public JuicedUp.Common.Economy.Public.Data.RewardType ConvertToRewardType(string voodooRewardItemName)
		{
			return default(JuicedUp.Common.Economy.Public.Data.RewardType);
		}

		public int ConvertToItemId(string voodooRewardItemName)
		{
			return 0;
		}
	}
}
