using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Feature.Ads;

namespace JuicedUp.Features.Support
{
	public class Freshdesk
	{
		private static readonly string _linkSuffix;

		private static readonly string _tempSupportLink;

		public static void OpenLink(string paidStatus)
		{
		}

		private static string GetLink(string paidStatus)
		{
			return null;
		}

		private static int GetBoosterCount(BoosterManager boosterManager, BoosterId boosterId)
		{
			return 0;
		}

		private static float GetCoinsBalance(IWallet wallet)
		{
			return 0f;
		}

		private static int GetCurrentLevel(Loading loading)
		{
			return 0;
		}

		private static int GetDaysSinceInstall(AdsPersistence adsPersistence)
		{
			return 0;
		}
	}
}
