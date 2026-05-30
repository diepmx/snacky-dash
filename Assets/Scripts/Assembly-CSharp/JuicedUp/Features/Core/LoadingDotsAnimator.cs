using DG.Tweening;
using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class LoadingDotsAnimator : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _label;

		[SerializeField]
		private float _dotInterval;

		private Sequence _sequence;

		private int _dotCount;

		private void Start()
		{
		}

		public void StopAnimation()
		{
		}

		public void StartAnimation()
		{
		}

		private void StepDot()
		{
		}

		private void UpdateText()
		{
		}
	}
}
