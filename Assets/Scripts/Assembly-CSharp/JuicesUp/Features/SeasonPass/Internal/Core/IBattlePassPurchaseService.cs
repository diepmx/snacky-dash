using System;
using Voodoo.Live.Offers;

namespace JuicesUp.Features.SeasonPass.Internal.Core
{
	internal interface IBattlePassPurchaseService
	{
		bool CanPurchasePremium { get; }

		void Dispose();

		string GetPremiumPrice();

		IFeature PurchasePremium(string placement, Action<bool> onComplete = null);
	}
}
