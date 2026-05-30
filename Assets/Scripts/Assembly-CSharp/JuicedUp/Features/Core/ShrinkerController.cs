using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(ShrinkerView))]
	public class ShrinkerController : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRegrowRoutineAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ShrinkerController _003C_003E4__this;

			public CancellationToken token;

			public float effectiveRegrowDuration;

			private float _003CstartSpacing_003E5__2;

			private float _003CtargetSpacing_003E5__3;

			private float _003Ctime_003E5__4;

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
		private struct _003CShrinkRoutineAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ShrinkerController _003C_003E4__this;

			public CancellationToken token;

			private float _003CeffectiveShrinkDuration_003E5__2;

			private float _003Ctime_003E5__3;

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
		private struct _003CStartStayShrunkPhase_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ShrinkerController _003C_003E4__this;

			public CancellationToken token;

			private float _003CeffectiveStayDuration_003E5__2;

			private float _003Ctime_003E5__3;

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
		private ShrinkerView _view;

		private float _defaultSpacingFactor;

		private bool _isStayingShrunk;

		private int _movesRemaining;

		private Player _player;

		private CancellationTokenSource _shrinkCts;

		private float _shrinkedSpacingFactor;

		private TailManager _tailManager;

		public static Action<bool> OnShrinking;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnLevelBuilt(LevelDataSO _, LevelMeta __)
		{
		}

		private void Init(TailManager tailManager, Player player)
		{
		}

		private void OnPlayerMove(Vector3Int position, TileType tileType)
		{
		}

		private void TriggerShrink()
		{
		}

		private void TriggerUnshrink()
		{
		}

		private void OnTriggeringBooster(BoosterId type)
		{
		}

		private float GetDurationMultiplier()
		{
			return 0f;
		}

		[AsyncStateMachine(typeof(_003CShrinkRoutineAsync_003Ed__18))]
		private UniTaskVoid ShrinkRoutineAsync(CancellationToken token)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CStartStayShrunkPhase_003Ed__19))]
		private UniTask StartStayShrunkPhase(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRegrowRoutineAsync_003Ed__20))]
		private UniTaskVoid RegrowRoutineAsync(float effectiveRegrowDuration, CancellationToken token)
		{
			return default(UniTaskVoid);
		}
	}
}
