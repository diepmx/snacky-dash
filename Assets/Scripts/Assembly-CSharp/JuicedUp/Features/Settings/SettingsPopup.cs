using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using JuicedUp.Common.Save;
using JuicedUp.Common.SaveAndLoad;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Lives;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Core.Scene;
using KiraganGames.Ui;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Settings
{
	public class SettingsPopup : BasePopupView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CConfirmAndExitToHome_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SettingsPopup _003C_003E4__this;

			public bool isAlreadyDefeated;

			public LivesService service;

			private UniTask<PopupButtonResult>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGoToHome_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public SettingsPopup _003C_003E4__this;

			private bool _003CisAlreadyDefeated_003E5__2;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private GameObject _backHomePanel;

		[SerializeField]
		private Button _backHomeButton;

		[SerializeField]
		private SettingsToggle[] _toggles;

		private IPopupService _popupService;

		private SettingsRepository _settingsRepository;

		private SettingsApplier _settingsApplier;

		private IDataRepository<PlayerProgressData> _progressRepository;

		private SettingsData _settingsData;

		private RemoteConfigService _remoteConfig;

		private StuckDetectionTracker _stuckDetectionTracker;

		private ICoreGameAnalyticsService _analyticsService;

		private ISceneService _sceneService;

		private IGameStateReader _gameStateReader;

		[Inject]
		private void Construct(IPopupService popupService, SettingsRepository settingsRepository, SettingsApplier settingsApplier, IDataRepository<PlayerProgressData> progressRepository, RemoteConfigService remoteConfig, StuckDetectionTracker stuckDetectionTracker, ICoreGameAnalyticsService analyticsService, ISceneService sceneService, IGameStateReader gameStateReader)
		{
		}

		protected override void OnSetup(IPopupPayload payload)
		{
		}

		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void OnBackHomeButton()
		{
		}

		public void CloseSettingsPopup()
		{
		}

		[AsyncStateMachine(typeof(_003CGoToHome_003Ed__19))]
		private UniTaskVoid GoToHome()
		{
			return default(UniTaskVoid);
		}

		private void ExitToHomeImmediately(LivesService service, bool isAlreadyDefeated)
		{
		}

		[AsyncStateMachine(typeof(_003CConfirmAndExitToHome_003Ed__21))]
		private UniTask ConfirmAndExitToHome(LivesService service, bool isAlreadyDefeated)
		{
			return default(UniTask);
		}

		private void ReloadScene(LivesService service, bool isAlreadyDefeated)
		{
		}

		public void ShowGDPRSettings()
		{
		}

		private void InitializeToggles()
		{
		}

		private bool GetSettingValue(SettingType settingType)
		{
			return false;
		}

		private void HandleToggleChanged(SettingType settingType, bool isOn)
		{
		}
	}
}
