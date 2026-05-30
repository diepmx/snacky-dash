using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using JuicedUp.Core.Bootstrap;
using UnityEngine.SceneManagement;

namespace JuicedUp.Features.Settings
{
	[UsedImplicitly]
	public class SettingsApplier : IAsyncInitializable, IDisposable
	{
		private readonly SettingsRepository _settingsRepository;

		private SettingsData _data;

		public SettingsApplier(SettingsRepository settingsRepository)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		public void ApplyMusic(bool enabled)
		{
		}

		public void ApplySound(bool enabled)
		{
		}

		public void ApplyHaptics(bool enabled)
		{
		}

		public void ApplyLanguage(string languageCode)
		{
		}
	}
}
