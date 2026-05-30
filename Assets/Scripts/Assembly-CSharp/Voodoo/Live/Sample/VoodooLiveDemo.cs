using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Voodoo.Live.Sample.Shop.UI;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample
{
	public class VoodooLiveDemo : MonoSingleton<VoodooLiveDemo>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStart_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public VoodooLiveDemo _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		public Button VLDebuggerBtn;

		public Button VSDebuggerBtn;

		public Button MainMenuTriggerBtn;

		public Button ClearInventoryBtn;

		[FormerlySerializedAs("SpinBtn")]
		public Button RestoreBtn;

		public GameShopUI gameShopUI;

		private VoodooLivePurchaseManager _voodooLivePurchaseManager;

		private bool isInitialized;

		[AsyncStateMachine(typeof(_003CStart_003Ed__8))]
		private void Start()
		{
		}

		private void Init()
		{
		}

		private void VoodooLiveInitialized()
		{
		}

		private void ShowVoodooLiveDebugger()
		{
		}

		private void ShowVoodooSauceDebugger()
		{
		}

		private static IOperator CreateCustomOperator(string key)
		{
			return null;
		}

		private void ShowVoodooLiveShop()
		{
		}
	}
}
