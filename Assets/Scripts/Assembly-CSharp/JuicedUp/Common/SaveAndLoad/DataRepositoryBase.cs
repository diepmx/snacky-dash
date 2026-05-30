using JuicedUp.Common.Save;

namespace JuicedUp.Common.SaveAndLoad
{
	public abstract class DataRepositoryBase
	{
		private static ES3Settings _settings;

		public static ES3Settings EncryptionSettings => null;

		public static void ConfigureEncryption(ES3SaveSettings saveSettings)
		{
		}
	}
}
