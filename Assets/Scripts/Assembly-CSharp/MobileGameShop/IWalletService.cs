namespace MobileGameShop
{
	public interface IWalletService
	{
		int Coins { get; }

		void AddCoins(int amount);
	}
}
