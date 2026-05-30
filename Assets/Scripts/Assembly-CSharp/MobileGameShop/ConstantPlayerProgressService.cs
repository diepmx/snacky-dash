namespace MobileGameShop
{
	public class ConstantPlayerProgressService : IPlayerProgressService
	{
		public int PlayerLevel { get; private set; }

		public ConstantPlayerProgressService(int level)
		{
		}
	}
}
