using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(TunnelView))]
	public class TunnelController : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitAndStartMonitoringAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public TunnelController _003C_003E4__this;

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
		private TunnelView _view;

		[SerializeField]
		private TailManager _tailManager;

		[SerializeField]
		private Transform _entranceTransform;

		[SerializeField]
		private Transform _exitTransform;

		private bool _entranceHidden;

		private bool _exitHidden;

		private bool _isReady;

		public GameObject TunnelEntrance => null;

		public GameObject TunnelExit => null;

		private void OnDisable()
		{
		}

		public void Init(TailManager tailManager)
		{
		}

		[AsyncStateMachine(typeof(_003CWaitAndStartMonitoringAsync_003Ed__13))]
		private UniTaskVoid WaitAndStartMonitoringAsync()
		{
			return default(UniTaskVoid);
		}

		private void OnTailUpdated(int tailLength)
		{
		}

		private void OnSnakeMovementEnded()
		{
		}

		private void EvaluateTunnelVisibility()
		{
		}
	}
}
