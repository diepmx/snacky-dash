using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class SnakeHeadView : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayEatBoosterAnimation_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SnakeHeadView _003C_003E4__this;

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

		[SerializeField]
		private MMFeedbacks _snakeHeadAppearFeedback;

		[Header("Eat Booster")]
		[Tooltip("Animator that owns the SnakeHead_EatBooster state. Optional: when null, no animator state is played.")]
		[SerializeField]
		private Animator _eatBoosterAnimator;

		[Tooltip("Animator state name to play on PlayEatBoosterAnimation. Defaults to the existing SnakeHead_EatBooster state.")]
		[SerializeField]
		private string _eatBoosterStateName;

		[Tooltip("Optional 'Snake Eating Glow' child GameObject. Activated for the duration of the eat animation, then deactivated. Null-safe.")]
		[SerializeField]
		private GameObject _eatingGlowGameObject;

		[Tooltip("Total duration the eat sequence is held in seconds. Should match the longer of the animator state and the glow effect.")]
		[SerializeField]
		private float _eatBoosterDuration;

		private int _eatBoosterStateHash;

		private string _eatBoosterStateNameCachedFor;

		public MMFeedbacks SnakeHeadAppearFeedback => null;

		[AsyncStateMachine(typeof(_003CPlayEatBoosterAnimation_003Ed__9))]
		public UniTask PlayEatBoosterAnimation(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}
