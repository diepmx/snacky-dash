using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Common.UI
{
	public class MainNavigationTransitionController : MonoBehaviour
	{
		private enum SwipeState
		{
			Home = 0,
			Shop = 1
		}

		[SerializeField]
		private RectTransform _topHud;

		[SerializeField]
		private RectTransform _homePanel;

		[SerializeField]
		private RectTransform _shopView;

		[SerializeField]
		private RectTransform _canvasRect;

		[SerializeField]
		private float _duration;

		[SerializeField]
		private Ease _ease;

		[SerializeField]
		private float _speedMultiplier;

		private SwipeState _currentState;

		private Sequence _activeSequence;

		public bool IsShopShown => false;

		private void Awake()
		{
		}

		private void SnapToHomeLayout()
		{
		}

		public UniTask SwipeToShop(CancellationToken ct = default(CancellationToken))
		{
			return default(UniTask);
		}

		public UniTask SwipeToHome(CancellationToken ct = default(CancellationToken))
		{
			return default(UniTask);
		}

		private static void SetAnchoredX(RectTransform rt, float x)
		{
		}
	}
}
