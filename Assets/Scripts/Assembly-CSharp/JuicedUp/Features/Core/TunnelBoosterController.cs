using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Lean.Touch;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(TunnelBoosterView))]
	public class TunnelBoosterController : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRefreshOverlaysLoopAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public TunnelBoosterController _003C_003E4__this;

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
		private TunnelBoosterView _view;

		private readonly List<TunnelController> _placedTunnelsThisSession;

		private TunnelController _lastPlacedTunnel;

		private CancellationTokenSource _refreshCts;

		public static Action OnPlacingTunnel;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		public void OnFingerTap(LeanFinger finger)
		{
		}

		private void PlaceTunnel(Vector3 position, Vector3Int bestCell)
		{
		}

		private bool TryGetBestCell(Vector3 worldPos, out Vector3Int bestCell)
		{
			bestCell = default(Vector3Int);
			return false;
		}

		public bool IsCellAllowedForTunnel(Vector3Int cell)
		{
			return false;
		}

		private void RefreshAndPushOverlays()
		{
		}

		[AsyncStateMachine(typeof(_003CRefreshOverlaysLoopAsync_003Ed__14))]
		private UniTaskVoid RefreshOverlaysLoopAsync(CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		public static bool ScreenToWorldOnXYPlane(Camera cam, Vector2 screenPos, float zPlane, out Vector3 world)
		{
			world = default(Vector3);
			return false;
		}
	}
}
