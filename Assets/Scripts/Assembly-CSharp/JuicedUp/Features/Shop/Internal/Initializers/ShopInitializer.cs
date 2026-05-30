using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Shop.Internal.Loaders;
using JuicedUp.Features.Shop.Internal.Providers;

namespace JuicedUp.Features.Shop.Internal.Initializers
{
	internal class ShopInitializer : IAsyncInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ShopInitializer _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		private IShopProductsProvider _shopProductsProvider;

		private IVoodooTuneShopLoader _voodooShopLoader;

		private bool _isInitialized;

		public ShopInitializer(IShopProductsProvider shopProductsProvider, IVoodooTuneShopLoader voodooShopLoader)
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__4))]
		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Dispose()
		{
		}

		private void OnVoodooLiveInitialized()
		{
		}

		private void OnShopReloadApplied()
		{
		}

		private void InitShopProductsProvider()
		{
		}
	}
}
