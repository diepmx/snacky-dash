using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Lives;
using JuicedUp.Features.Core.Popup;
using JuicedUp.Features.Shop.Internal.Controllers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TopHUDPanel : MonoBehaviour, IAsyncInitializable
{
	[SerializeField]
	private RewardHudView[] _topRewardHudViews;

	[SerializeField]
	private TMP_Text _timerText;

	[SerializeField]
	private Image _imageInfinite;

	[SerializeField]
	private Image _imageLivePlus;

	[SerializeField]
	private Button _settings;

	[SerializeField]
	private Button _livesPanelButton;

	[SerializeField]
	private Button _coinsPanelButton;

	private IPopupService _popupService;

	private IEconomyService _economyService;

	private IShopViewController _shopViewController;

	private IRewardHudRegister _rewardHudRegister;

	private BottomHudPanel _bottomHud;

	private IGameStateReader _gameStateReader;

	[Inject]
	private void Construct(IPopupService popupService, IEconomyService economyService, IShopViewController shopViewController, IRewardHudRegister rewardHudRegister, BottomHudPanel bottomHud, IGameStateReader gameStateReader)
	{
	}

	public UniTask InitAsync(CancellationToken _)
	{
		return default(UniTask);
	}

	public void RegisterHudView()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void HandleLivesServiceReady(LivesService service)
	{
	}

	private void HandleLivesChanged(int current, int max)
	{
	}

	private void RenderTimer(int secondsRemaining)
	{
	}

	private void OpenSettings()
	{
	}

	private void OnGameStateChanged(GameState state, DefeatType defeatType)
	{
	}

	private void UpdateAllCurrency()
	{
	}

	private void OnStartingGame()
	{
	}

	private void OpenRefillLivesPopup()
	{
	}

	private void OnCoinsPanelButtonClick()
	{
	}
}
