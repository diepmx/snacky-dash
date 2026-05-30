using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.Economy.Scripts.Public.Factories;
using JuicedUp.Common.Notifiers;
using JuicedUp.Common.Tooltips.Data;
using JuicedUp.Common.Tooltips.Views;
using JuicedUp.Features.Core;

namespace JuicedUp.Common.Tooltips.Controllers
{
	public class CommonTooltipController : ITooltipController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHideTooltip_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CommonTooltipController _003C_003E4__this;

			public bool withAnimation;

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
		private struct _003CLoadTooltipView_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CommonTooltipController _003C_003E4__this;

			public TooltipPayload payload;

			public CancellationToken token;

			private UniTask<CommonTooltipView>.Awaiter _003C_003Eu__1;

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
		private struct _003COnTooltipExecutedAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CommonTooltipController _003C_003E4__this;

			public CancellationToken token;

			public TooltipPayload payload;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<int>.Awaiter _003C_003Eu__2;

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
		private struct _003CShowTooltip_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CommonTooltipController _003C_003E4__this;

			public TooltipPayload payload;

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

		private const float TooltipAutoCloseDuration = 5f;

		private readonly IRequestListener<TooltipPayload> _tooltipListener;

		private readonly List<IRewardView> _rewardViews;

		private readonly IRewardViewFactory _rewardViewFactory;

		private readonly IManagedAssetLoader _managedAssetLoader;

		private CancellationTokenSource _executionTokenSource;

		private ICommonTooltipView _commonTooltipView;

		private string _loadedTooltipAssetKey;

		private bool _isShowed;

		public CommonTooltipController(IRequestListener<TooltipPayload> tooltipListener, IRewardViewFactory rewardViewFactory, IManagedAssetLoader managedAssetLoader)
		{
		}

		public UniTask Initialize(CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask Execute(CancellationToken token)
		{
			return default(UniTask);
		}

		public void Deactivate()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnTooltipRequested(TooltipPayload payload)
		{
		}

		[AsyncStateMachine(typeof(_003COnTooltipExecutedAsync_003Ed__16))]
		private UniTask OnTooltipExecutedAsync(TooltipPayload payload, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CShowTooltip_003Ed__17))]
		private UniTask ShowTooltip(TooltipPayload payload, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHideTooltip_003Ed__18))]
		private UniTask HideTooltip(bool withAnimation, CancellationToken token)
		{
			return default(UniTask);
		}

		private void ReleaseRewardViews()
		{
		}

		private void SetupRewards(IEnumerable<IReward> rewards)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadTooltipView_003Ed__21))]
		private UniTask LoadTooltipView(TooltipPayload payload, CancellationToken token)
		{
			return default(UniTask);
		}
	}
}
