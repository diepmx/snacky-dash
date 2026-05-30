namespace MobileGameShop
{
	public class PlayerPrefsWalletService : IWalletService
	{
		private const string Key = "MGS_WALLET_COINS";

		public int Coins => 0;

		public void AddCoins(int amount)
		{
		}
	}
}
