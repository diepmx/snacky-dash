using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Common.Ftue;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Features.Ads.Scripts.Controllers
{
	public class NoAdsFtueController : INoAdsFtueController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CActivate_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public NoAdsFtueController _003C_003E4__this;

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

		private readonly IEntitlementStorage _entitlementStorage;

		private readonly IFtueRepository _ftueRepository;

		private readonly IPopupService _popupService;

		public NoAdsFtueController(IEntitlementStorage entitlementStorage, IFtueRepository ftueRepository, IPopupService popupService)
		{
		}

		[AsyncStateMachine(typeof(_003CActivate_003Ed__4))]
		public UniTask Activate()
		{
			return default(UniTask);
		}
	}
}
