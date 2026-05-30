using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(BridgeView))]
	public class BridgeController : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public int version;

			public BridgeController _003C_003E4__this;

			public CancellationToken token;

			public bool withSound;

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
		private BridgeView _view;

		private TileType _bridgeTypeAtCell;

		private TileType _openBridgeType;

		private Vector3Int _cell;

		private Vector3Int _playerCell;

		private CancellationTokenSource _cancellationTokenSource;

		private SwitchToggleState _desiredState;

		private bool _isInitialized;

		private int _requestVersion;

		private SnakeOccupancyManager _occupancy;

		private LevelController _levelController;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Init(Vector3Int cell, SnakeOccupancyManager occupancy, LevelController levelController)
		{
		}

		public void RequestOpen()
		{
		}

		public void RequestClose()
		{
		}

		private void SetDesired(SwitchToggleState state)
		{
		}

		private void ForceRecheck()
		{
		}

		private void StartRun(bool withSound)
		{
		}

		[AsyncStateMachine(typeof(_003CRunAsync_003Ed__19))]
		private UniTaskVoid RunAsync(int version, bool withSound, CancellationToken token)
		{
			return default(UniTaskVoid);
		}

		private void ApplyState(SwitchToggleState state, bool withSound)
		{
		}

		private bool CanOpenNow(Vector3Int cell)
		{
			return false;
		}

		private bool CanCloseNow(Vector3Int cell)
		{
			return false;
		}

		private bool IsCellEmpty(Vector3Int cell)
		{
			return false;
		}

		private bool IsCellEmptyOneOnly(Vector3Int cell)
		{
			return false;
		}

		private static bool IsUnderBridgeShape(SegmentShape shape, TileType bridgeType)
		{
			return false;
		}
	}
}
