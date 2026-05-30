using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Core.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace JuicedUp.Features.Core.Lives
{
	public class RefillLivesPopupView : BasePopupView
	{
		[Header("Header")]
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[Header("Heart Display")]
		[SerializeField]
		private TextMeshProUGUI _livesCountText;

		[SerializeField]
		private Image _infinityImage;

		[Header("Timer")]
		[SerializeField]
		private TextMeshProUGUI _timerText;

		[Header("Get 1 Life -- Rewarded Ad")]
		[SerializeField]
		private GameObject _getOneGroup;

		[SerializeField]
		private Button _getOneButton;

		[Header("Refill All -- Gem Purchase")]
		[SerializeField]
		private GameObject _refillAllGroup;

		[SerializeField]
		private Button _refillAllButton;

		[SerializeField]
		private Transform _refillCostContainer;

		[SerializeField]
		private TMP_Text _refillCostText;

		[SerializeField]
		private TMP_Text _refillFreeText;

		[Header("Close")]
		[SerializeField]
		private Button _closeButton;

		private RefillLivesPopupPayload _payload;

		private ICoreGameAnalyticsService _analyticsService;

		private LivesService _livesService;

		[Inject]
		private void Construct(ICoreGameAnalyticsService analyticsService)
		{
		}

		protected override void OnSetup(IPopupPayload payload)
		{
		}

		protected override UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected override UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		private void UnsubscribeFromLivesService()
		{
		}

		private void RefreshUI()
		{
		}

		private void HandleSecondsChanged(int seconds)
		{
		}

		private void HandleLivesChanged(int current, int max)
		{
		}

		private void HandleRvAvailabilityChanged(bool isAvailable)
		{
		}

		private void OnGetOnePressed()
		{
		}

		private void OnRefillAllPressed()
		{
		}

		private void OnClosePressed()
		{
		}

		public override void SetInteractable(bool interactable)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
