namespace JuicedUp.Common.Util
{
	public class AppRaterHelper
	{
		private const int MaxLifetimePrompts = 3;

		private readonly AppRaterRepository _repository;

		public AppRaterHelper(AppRaterRepository repository)
		{
		}

		public void TryShowRatePrompt()
		{
		}
	}
}
