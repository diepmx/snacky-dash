using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Tutorial
{
	[DisallowMultipleComponent]
	public sealed class BoosterForcedTutorialView : MonoBehaviour, IBoosterForcedTutorialView
	{
		private Transform _originalParent;

		private bool _destroyed;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Show(BoosterId id)
		{
		}

		public void Hide()
		{
		}
	}
}
