using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMilestoneProgressBarView : MonoBehaviour
	{
		[SerializeField]
		private Image _sliderImage;

		[SerializeField]
		private Slider _progressSlider;

		[SerializeField]
		private GameObject _tooltip;

		[SerializeField]
		private TMP_Text _tooltipText;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private float _tooltipPopDuration;

		[SerializeField]
		private float _tooltipPopStartScale;

		private Tween _tooltipPopTween;

		private bool _isTooltipVisible;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void ShowTooltip()
		{
		}

		private void HideTooltip()
		{
		}

		private void CancelTooltipFlow()
		{
		}

		private void CancelTooltipTweens()
		{
		}

		public void SetProgress(float progress)
		{
		}

		public void SetProgress(int progress, int target)
		{
		}

		private void UpdateProgressText(int progress, int target)
		{
		}
	}
}
