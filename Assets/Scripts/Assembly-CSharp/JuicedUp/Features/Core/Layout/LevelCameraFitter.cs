using Cinemachine;
using DG.Tweening;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Features.Core.Layout
{
	[ExecuteAlways]
	public class LevelCameraFitter : MonoBehaviour
	{
		private enum UpdateType
		{
			None = 0,
			OnPlayMode = 1,
			OnPlayModeAndEditorMode = 2
		}

		private enum LevelBoundsProvider
		{
			GameObject = 0,
			JuicedUp = 1
		}

		[SerializeField]
		private CinemachineVirtualCamera _virtualCamera;

		[SerializeField]
		private Transform _cameraTransform;

		[SerializeField]
		private RectTransform _fitAreaReference;

		[SerializeField]
		private Vector3 _cameraOffset;

		[SerializeField]
		private UpdateType _updateType;

		[SerializeField]
		private LevelBoundsProvider _levelBoundsProvider;

		[Header("Bounds Extender")]
		[SerializeField]
		private float _expandBoundsY;

		[SerializeField]
		private float _expandBoundsX;

		[SerializeField]
		private float _cannonBoosterOrthographicSizeOffset;

		[SerializeField]
		private float _boosterOrthographicSizeTweenDuration;

		[Header("For gameobject level bounds - testing only")]
		[SerializeField]
		private GameObject _level;

		[SerializeField]
		private Camera _camera;

		private GameObjectBoundsProvider _gameObjectBoundsProvider;

		private JuicedUpLevelBoundsProvider _juicedUpLevelBoundsProvider;

		private Bounds _cachedBounds;

		private bool _hasCachedBounds;

		private float _cachedLevelOrthographicSize;

		private bool _hasCachedLevelOrthographicSize;

		private bool _isCannonBoosterFocusActive;

		private Tween _orthographicSizeTween;

		public Transform CameraTransform => null;

		public bool TryGetLevelBoundsCenter(out Vector3 center)
		{
			center = default(Vector3);
			return false;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void FitLevel()
		{
		}

		private Bounds CalculateLevelBounds()
		{
			return default(Bounds);
		}

		private float FitToLevelBounds(Bounds bounds)
		{
			return 0f;
		}

		private void OnTriggerBoosterFocus(BoosterId type)
		{
		}

		private void OnTriggeringBooster(BoosterId type)
		{
		}

		private void OnCancelBoosterFocus(BoosterId type)
		{
		}

		private void ResetCannonBoosterFocus()
		{
		}

		private void ApplyCurrentOrthographicSize(bool animate)
		{
		}

		public float GetCurrentOrthographicSize()
		{
			return 0f;
		}

		private void SetCurrentOrthographicSize(float orthographicSize)
		{
		}

		private void DrawLevelBounds()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
