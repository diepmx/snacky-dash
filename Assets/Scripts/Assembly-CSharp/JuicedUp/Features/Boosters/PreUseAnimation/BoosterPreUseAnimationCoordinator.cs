using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Boosters.PreUseAnimation
{
	public class BoosterPreUseAnimationCoordinator : MonoBehaviour, IBoosterPreUseAnimationCoordinator
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlayAsync_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BoosterPreUseAnimationCoordinator _003C_003E4__this;

			public BoosterId boosterId;

			public CancellationToken cancellationToken;

			private Transform _003Ctrail_003E5__2;

			private Transform _003Chead_003E5__3;

			private CancellationToken _003Ctoken_003E5__4;

			private UniTask _003CeatTask_003E5__5;

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
		private struct _003CSinkTrailIntoHead_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BoosterPreUseAnimationCoordinator _003C_003E4__this;

			public Transform head;

			public Transform trail;

			public CancellationToken token;

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
		private struct _003CStartEatAfterDelayAsync_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public float delay;

			public CancellationToken token;

			public SnakeHeadView snakeHeadView;

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

		[Tooltip("Inspector reference to the BoosterTrailRegistry on the BoosterTrailsVFX prefab instance in the scene.")]
		[SerializeField]
		private BoosterTrailRegistry _trailRegistry;

		[Header("Tuning")]
		[Tooltip("Duration in seconds for the trail to fly from button to snake head.")]
		[SerializeField]
		[Min(0f)]
		private float _flyDuration;

		[Tooltip("Easing of the X-axis fly motion. Combined with _flyEaseY this produces an arc instead of a straight line. Default InQuad means slow X movement at start, accelerating toward the end.")]
		[SerializeField]
		private Ease _flyEaseX;

		[Tooltip("Easing of the Y-axis fly motion. Default OutQuad means fast Y movement at start, decelerating toward the end. Pairing OutQuad on Y with InQuad on X produces a 'rise first, then over' arc, like a thrown object.")]
		[SerializeField]
		private Ease _flyEaseY;

		[Tooltip("World Z plane the trail flies on. Both the start (button) and end (snake head) world points are projected onto this Z so the trail stays on a fixed plane.")]
		[SerializeField]
		private float _flyZ;

		[Tooltip("Active trail uniform localScale at the start of the fly (button-side).")]
		[SerializeField]
		[Min(0f)]
		private float _startScale;

		[Tooltip("Active trail uniform localScale when it arrives at the snake head.")]
		[SerializeField]
		[Min(0f)]
		private float _endScale;

		[Header("Approach + Sink")]
		[Tooltip("Offset (in the snake head's LOCAL space) from the head's pivot to the 'approach point' the trail flies to. Sits a bit in front of the head so the eat animation looks like the snake is reaching out for the trail. Tweak axis/distance live in the inspector.")]
		[SerializeField]
		private Vector3 _approachLocalOffset;

		[Tooltip("Duration of the secondary 'sink into head' tween that runs concurrently with the snake's eat animation. Trail moves from approach point INTO head.position and scales to _sinkScale.")]
		[SerializeField]
		[Min(0f)]
		private float _sinkDuration;

		[Tooltip("Easing of the sink-into-head motion.")]
		[SerializeField]
		private Ease _sinkEase;

		[Tooltip("Trail uniform localScale at the end of the sink (when it disappears inside the head).")]
		[SerializeField]
		[Min(0f)]
		private float _sinkScale;

		[Tooltip("How many seconds BEFORE the fly tween ends should the snake head's eat animation start? Lets the chomp pre-empt the trail's arrival so the snake looks like it's reaching out to bite. Clamped to [0, _flyDuration]; 0 = legacy behavior (eat starts when fly ends).")]
		[SerializeField]
		[Min(0f)]
		private float _eatLeadTime;

		private Player _player;

		private readonly Dictionary<BoosterId, RectTransform> _buttonAnchors;

		private Tween _flyTween;

		private Tween _flyTweenY;

		private Tween _scaleTween;

		private Transform _activeTrail;

		private Vector3 _activeTrailDefaultLocalPos;

		private Vector3 _activeTrailDefaultLocalScale;

		private CancellationTokenSource _activeAnimationCts;

		public bool IsAnimating { get; private set; }

		[Inject]
		public void Construct(Player player, BoosterButtonUI[] boosterButtons)
		{
		}

		private void BuildAnchorMap(BoosterButtonUI[] boosterButtons)
		{
		}

		[AsyncStateMachine(typeof(_003CPlayAsync_003Ed__27))]
		public UniTask PlayAsync(BoosterId boosterId, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private void CancelActiveAnimation()
		{
		}

		private void DisposeActiveAnimationCts()
		{
		}

		[AsyncStateMachine(typeof(_003CStartEatAfterDelayAsync_003Ed__30))]
		private UniTask StartEatAfterDelayAsync(SnakeHeadView snakeHeadView, float delay, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CSinkTrailIntoHead_003Ed__31))]
		private UniTask SinkTrailIntoHead(Transform trail, Transform head, CancellationToken token)
		{
			return default(UniTask);
		}

		private void HideActiveTrail()
		{
		}

		private void PrepareTrailAtButton(Transform trail, RectTransform anchor, Camera camera)
		{
		}

		private void StartFlyTweens(Transform trail, Transform head, UniTaskCompletionSource onArrived)
		{
		}

		private Vector3 ComputeApproachWorldPoint(Transform head)
		{
			return default(Vector3);
		}

		private void EndTrail()
		{
		}

		private Vector3 ConvertAnchorToWorld(RectTransform anchor, Camera camera, float targetZ)
		{
			return default(Vector3);
		}

		private void OnDisable()
		{
		}
	}
}
