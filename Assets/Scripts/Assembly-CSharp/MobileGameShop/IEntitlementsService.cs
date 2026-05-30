namespace MobileGameShop
{
	public interface IEntitlementsService
	{
		bool IsTrue(string key);

		void SetBool(string key, bool value);
	}
}
