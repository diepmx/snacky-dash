using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace JuicedUp.Features.Core.Popup
{
	public class PopupRegistry
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<BasePopupView> _003C_003Et__builder;

			public PopupRegistry _003C_003E4__this;

			public PopupId id;

			public CancellationToken ct;

			private string _003Cpath_003E5__2;

			private UniTask<UnityEngine.GameObject>.Awaiter _003C_003Eu__1;

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

		private const string BasePath = "Popups/";

		private readonly IAssetLoader _assetLoader;

		private readonly Dictionary<PopupId, BasePopupView> _cache;

		public PopupRegistry(IAssetLoader assetLoader)
		{
		}

		public BasePopupView Load(PopupId id)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__5))]
		public UniTask<BasePopupView> LoadAsync(PopupId id, CancellationToken ct = default(CancellationToken))
		{
			return default(UniTask<BasePopupView>);
		}

		public void ClearCache()
		{
		}
	}
}
