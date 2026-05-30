using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class PlayerView : MonoBehaviour
	{
		private const float MinTunnelDepth = 5f;

		[Header("Gameplay")]
		[SerializeField]
		private float _moveSpeed;

		[SerializeField]
		private float _moveSpeedAbove;

		[SerializeField]
		private bool _rotate;

		[SerializeField]
		private bool _dieWhenEatingTale;

		[SerializeField]
		private bool _respawnPillsEnemyKilled;

		[FormerlySerializedAs("_respawnPillsPlayerKilledByEnnemy")]
		[SerializeField]
		private bool _respawnPillsPlayerKilledByEnemy;

		[SerializeField]
		private float _reviveRepositionDuration;

		[SerializeField]
		private LayerMask _bridgeTriggerMask;

		[Header("Scale")]
		[SerializeField]
		private Vector3 _defaultScale;

		[SerializeField]
		private Vector3 _startStretch;

		[SerializeField]
		private Vector3 _stopStretch;

		[SerializeField]
		private float _scaleDuration;

		[Header("Bump")]
		[SerializeField]
		private float _bumpDistance;

		[SerializeField]
		private float _bumpArrowDistance;

		[SerializeField]
		private float _bumpForwardDuration;

		[SerializeField]
		private float _bumpReturnDuration;

		[Header("Spawn")]
		[SerializeField]
		private float _spawnDropHeight;

		[SerializeField]
		private float _spawnDuration;

		[Header("Bridge State")]
		[SerializeField]
		private float _aboveZDuration;

		[SerializeField]
		private AnimationCurve _aboveZCurve;

		[SerializeField]
		private float _aboveRotationFactor;

		[SerializeField]
		private float _aboveXRotation;

		[Header("Tunnel")]
		[SerializeField]
		private float _exitTunnelZDepth;

		[SerializeField]
		private float _tunnelZDepthMultiplier;

		[Header("Tunnel Enter")]
		[SerializeField]
		private float _tunnelEnterMultiplier;

		[SerializeField]
		private float _enterDurationMin;

		[SerializeField]
		private float _enterDurationMax;

		[SerializeField]
		private Ease _enterEase;

		[Header("Tunnel Exit")]
		[SerializeField]
		private float _tunnelExitMultiplier;

		[SerializeField]
		private float _exitDurationMin;

		[SerializeField]
		private float _exitDurationMax;

		[Header("Tunnel Travel Point A to B")]
		[SerializeField]
		private float _tunnelTravelMultiplier;

		[SerializeField]
		private float _travelDurationMin;

		[SerializeField]
		private float _travelDurationMax;

		[Header("References")]
		[SerializeField]
		private Collider2D _colliderSnakeHead;

		private Transform _playerTransform;

		private SnakeHeadView _snakeHeadView;

		private Tween _headScaleTween;

		private Tween _headPositionTween;

		private Tween _bridgeZTween;

		private Tween _bridgeRotationTween;

		private Quaternion _neutralLocalRotation;

		private float _bridgeTweenProgress;

		public float MoveSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MoveSpeedAbove
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Rotate => false;

		public bool DieWhenEatingTale => false;

		public bool RespawnPillsEnemyKilled => false;

		public bool RespawnPillsPlayerKilledByEnemy => false;

		public float ReviveRepositionDuration => 0f;

		public LayerMask BridgeTriggerMask => default(LayerMask);

		public Collider2D ColliderSnakeHead => null;

		public Transform SnakeHeadTransform => null;

		public SnakeHeadView SnakeHeadView => null;

		public void HandleHeadSpawned(Transform playerTransform)
		{
		}

		public void HandleSpawn(Transform playerTransform)
		{
		}

		private void OnPlayerAppearFxComplete()
		{
		}

		public void HandleReScale()
		{
		}

		public void HandleBump(DirectionPlayer direction, Vector3 playerWorldPos)
		{
		}

		public void HandleBumpArrow(DirectionPlayer direction, Vector3 playerWorldPos)
		{
		}

		public void HandleStartMoving()
		{
		}

		public void HandleStateChanged(State state)
		{
		}

		public void HandleTailHit()
		{
		}

		public void HandleCellArrival()
		{
		}

		public void HandleKillAllTweens()
		{
		}

		public void HandleHeadReset()
		{
		}

		public void HandleTunnelTraversal(Transform playerTransform, Vector3 exitWorld, int tailLength, Action onUpdate, Action onComplete)
		{
		}

		private Tween PlayWithReturn(Tween current, Func<Tween> forward, Func<Tween> back = null)
		{
			return null;
		}

		private Tween FollowCurveOnZAxis(float startProgress, float duration, AnimationCurve curve)
		{
			return null;
		}

		private Tween FollowCurveTangentOnXRotation(float startProgress, float duration, AnimationCurve curve)
		{
			return null;
		}

		private float GetTangent(AnimationCurve curve, float time)
		{
			return 0f;
		}
	}
}
