using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.FeatureOriented;
using JuicedUp.Common.UI;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.WeeklyMissions.Public;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class WeeklyMissionFtueBadgeController : IWeeklyMissionFtueBadgeController, IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivateControllerLoop_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionFtueBadgeController _003C_003E4__this;

			public CancellationToken token;

			public Transform badgeTransform;

			private CancellationTokenSource _003ClinkedTokenSource_003E5__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecute_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionFtueBadgeController _003C_003E4__this;

			public CancellationToken token;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionFtueBadgeController _003C_003E4__this;

			public CancellationToken token;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadFtueView_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionFtueBadgeController _003C_003E4__this;

			public CancellationToken token;

			private UniTask<WeeklyMissionBadgeFtueView>.Awaiter _003C_003Eu__1;

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
		private struct _003CPrewarmAssets_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public WeeklyMissionFtueBadgeController _003C_003E4__this;

			public CancellationToken token;

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

		private const string FtueBadgeCompletedKey = "WM_FtueBadgeCompleted";

		private static readonly Vector3 BadgePositionOffset;

		private readonly IWeeklyMissionsPopupController _weeklyMissionsController;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private readonly ICanvasesProvider _canvasesProvider;

		private readonly IFeatureAvailabilityProvider _featureStatusProvider;

		private IBadgeFtueView _badgeFtueView;

		private CancellationTokenSource _controllerTokenSource;

		private CancellationToken _generalToken;

		private Transform _badgeTransform;

		private IDisposable _featureStatusSubscription;

		private bool _isDeactivationRequested;

		private bool _isActive;

		private bool _assetsDestroyed;

		private bool _badgeHiddenApplied;

		private bool _badgeOriginalActiveState;

		public WeeklyMissionFtueBadgeController(IWeeklyMissionsPopupController weeklyMissionsController, IManagedAssetLoader managedAssetLoader, ICanvasesProvider canvasesProvider, [Key(FeatureIds.WeeklyMissions)] IFeatureAvailabilityProvider featureStatusProvider)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CActivateControllerLoop_003Ed__19))]
		public UniTask ActivateControllerLoop(Transform badgeTransform, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__20))]
		public UniTask Initialize(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CExecute_003Ed__21))]
		public UniTask Execute(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask Deactivate(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnFeatureInitialized(bool isInitialized)
		{
		}

		[AsyncStateMachine(typeof(_003CPrewarmAssets_003Ed__24))]
		private UniTask PrewarmAssets(CancellationToken token)
		{
			return default(UniTask);
		}

		private void OnBadgeButtonClicked()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadFtueView_003Ed__26))]
		private UniTask LoadFtueView(CancellationToken token)
		{
			return default(UniTask);
		}

		private bool IsAvailable()
		{
			return false;
		}

		private void SafeUnsubscribeBadgeClick()
		{
		}

		private void SafeDestroyFtueView()
		{
		}

		private static bool IsUnityAlive(object obj)
		{
			return false;
		}

		private void HideOriginalBadge()
		{
		}

		private void RestoreOriginalBadge()
		{
		}
	}
}
