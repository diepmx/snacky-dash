using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using JuicedUp.Common.Config;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Features.ForceUpdate
{
	[UsedImplicitly]
	public class ForceUpdateService : IAsyncInitializable
	{
		private readonly IPopupService _popupService;

		private readonly RemoteConfigService _remoteConfigService;

		public ForceUpdateService(RemoteConfigService remoteConfigService, IPopupService popupService)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void CheckVersion()
		{
		}

		private void ShowForceUpdatePopup(ForceUpdateConfig config, string storeLink)
		{
		}

		private void OnUpdateButtonClicked(string storeLink, string minimumVersion)
		{
		}

		private static string GetStoreLink(ForceUpdateConfig config)
		{
			return null;
		}
	}
}
