using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Scripts.Public.Registrars;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.Analytics;
using JuicedUp.Features.Shop.Internal.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterBuyUI : MonoBehaviour
{
	[SerializeField]
	private CurrencyRewardHudView _coinRewardHudView;

	[SerializeField]
	private Button _coinRewardHudButton;

	public BoosterId currentBoosterType;

	public TextMeshProUGUI boosterNameText;

	public TextMeshProUGUI boosterInfoText;

	public TextMeshProUGUI boosterPriceText;

	public TextMeshProUGUI boosterNumber;

	public Image boosterImage;

	public SwipeController swipeController;

	private IEconomyService _economyService;

	private IRewardHudRegister _rewardHudRegister;

	private IShopViewController _shopViewController;

	private ICoreGameAnalyticsService _analyticsService;

	public void Construct(IEconomyService economyService, IRewardHudRegister rewardHudRegister, IShopViewController shopViewController, ICoreGameAnalyticsService analyticsService)
	{
	}

	public void ClosePanel()
	{
	}

	public void SetBoosterBuy(BoosterId boosterType)
	{
	}

	public void TryToBuy()
	{
	}

	private void OpenShop()
	{
	}

	private void OnShopClosed(IProduct purchasedProduct)
	{
	}

	private void ToggleCoinUI(bool enabled)
	{
	}

	private void OnCoinRewardHudButtonClicked()
	{
	}
}
