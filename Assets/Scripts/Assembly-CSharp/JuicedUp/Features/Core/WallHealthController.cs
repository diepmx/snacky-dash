using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class WallHealthController : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTakeDamageAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public WallHealthController _003C_003E4__this;

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
		private WallView _view;

		[SerializeField]
		private int _idGroup;

		[SerializeField]
		private float _delayBeforeDamage;

		private CancellationToken _destroyCancellationToken;

		private PillManager _pillManager;

		private LevelController _levelController;

		private Vector3Int? _blockerCell;

		private int _destructibleWallGroupId;

		private int _destructibleWallHealth;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnLevelBuilt(LevelDataSO levelData, LevelMeta _)
		{
		}

		public void Init(LevelController levelController, PillManager pillManager, Vector3Int? blockerCell)
		{
		}

		private int ResolveDestructibleWallGroupId()
		{
			return 0;
		}

		private static int ResolveDestructibleWallHealth(LevelDataSO levelData, int groupId)
		{
			return 0;
		}

		private void HandleCrateCompleted(PillKind pillKind)
		{
		}

		[AsyncStateMachine(typeof(_003CTakeDamageAsync_003Ed__16))]
		private UniTaskVoid TakeDamageAsync()
		{
			return default(UniTaskVoid);
		}

		private void BreakWall()
		{
		}

		private void UnlockLinkedPillGroups()
		{
		}
	}
}
