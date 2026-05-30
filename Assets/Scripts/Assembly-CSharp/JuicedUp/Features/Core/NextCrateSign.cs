using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class NextCrateSign : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private GameObject _visualRoot;

		[SerializeField]
		private List<GameObject> _platforms;

		[SerializeField]
		private SpriteRenderer _currentFruitIcon;

		[SerializeField]
		private SpriteRenderer _nextFruitIcon;

		[Header("Kind Change Spin")]
		[SerializeField]
		private Transform _spinOrigin;

		[SerializeField]
		private Vector3 _spinAmount;

		[SerializeField]
		private float _spinDelay;

		[SerializeField]
		private float _spinDuration;

		[SerializeField]
		private Ease _spinEase;

		private bool _initialized;

		private SpriteRenderer _frontSlot;

		private SpriteRenderer _backSlot;

		private Tween _spinTween;

		private void Awake()
		{
		}

		public void SetPlatformIndex(int index)
		{
		}

		public void SetPillKind(PillKind kind)
		{
		}

		public void Hide()
		{
		}

		private void PlaySpinTween(PillKind kind)
		{
		}

		private void SetSprite(SpriteRenderer slot, PillKind kind)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
