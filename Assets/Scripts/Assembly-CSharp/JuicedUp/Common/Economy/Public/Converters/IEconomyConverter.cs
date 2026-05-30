using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using Voodoo.Live;

namespace JuicedUp.Common.Economy.Public.Converters
{
	public interface IEconomyConverter
	{
		IEnumerable<JuicedUp.Common.Economy.Public.Data.IReward> ConvertToRewards(IEnumerable<ICost> costs);

		IEnumerable<JuicedUp.Common.Economy.Public.Data.IReward> ConvertToRewards(IEnumerable<ItemQuantityDTO> rewardItems);

		IEnumerable<IProduct> ConvertToProducts(IEnumerable<ProductDTO> productDtos);

		JuicedUp.Common.Economy.Public.Data.RewardType ConvertToRewardType(string voodooRewardItemName);

		int ConvertToItemId(string voodooRewardItemName);
	}
}
