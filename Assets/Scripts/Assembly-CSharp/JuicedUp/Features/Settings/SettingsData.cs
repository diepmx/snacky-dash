using System;

namespace JuicedUp.Features.Settings
{
	[Serializable]
	public class SettingsData
	{
		public bool MusicEnabled;

		public bool SoundEnabled;

		public bool HapticsEnabled;

		public bool AlertsEnabled;

		public string LanguageCode;
	}
}
