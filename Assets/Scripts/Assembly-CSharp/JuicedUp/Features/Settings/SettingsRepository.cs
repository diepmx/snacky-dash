using JuicedUp.Common.SaveAndLoad;

namespace JuicedUp.Features.Settings
{
	public class SettingsRepository
	{
		private readonly IDataRepository<SettingsData> _repository;

		public SettingsRepository(IDataRepository<SettingsData> repository)
		{
		}

		public SettingsData LoadSettings()
		{
			return null;
		}

		public void SaveSettings()
		{
		}
	}
}
