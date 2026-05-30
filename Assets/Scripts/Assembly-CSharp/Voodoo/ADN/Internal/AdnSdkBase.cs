namespace Voodoo.ADN.Internal
{
	internal abstract class AdnSdkBase
	{
		private bool _isInitialized;

		public void Initialize(AdnSdkInitializationMode initializationMode)
		{
		}

		protected abstract void InitializeSdk();

		protected static void HandleEventBackgroundCallback(string propsStr)
		{
		}

		private static void ApplyPreferences()
		{
		}
	}
}
