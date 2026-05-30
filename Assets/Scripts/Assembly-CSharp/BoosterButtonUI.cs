using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Services;
using JuicedUp.Common.Economy.Public.Storages;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Boosters.Tutorial;
using JuicedUp.Features.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterButtonUI : MonoBehaviour, IAsyncInitializable, IDisposable
{
	private const float TutorialPulseDelay = 1f;

	public BoosterId type;

	public TextMeshProUGUI unlockLevelText;

	public Button button;

	public GameObject lockedPanel;

	public CanvasGroup canvasGroupButton;

	public ScalableButtonFeedback scalableButtonFeedback;

	public Image imageGlow;

	[SerializeField]
	private Image _boosterIconImage;

	[SerializeField]
	private TextMeshProUGUI _countText;

	[SerializeField]
	private GameObject _buyMoreGameObject;

	[SerializeField]
	private GameObject _countParentGameobject;

	[SerializeField]
	[Tooltip("Optional 'FREE' badge GameObject shown when the first-free usage is pending.")]
	private GameObject _freeBadge;

	[SerializeField]
	private GameObject _unlockLevelParentGameobject;

	private int _lastCount;

	private bool _isUnlocked;

	private BoosterManager _boosterManager;

	private IWallet _wallet;

	private Tweener _glowPulseTween;

	private IEconomyService _economyService;

	private BoosterTutorialState _tutorialState;

	private IGameStateReader _gameStateReader;

	public void Construct(BoosterManager boosterManager, IWallet wallet, IEconomyService economyService, BoosterTutorialState tutorialState, IGameStateReader gameStateReader)
	{
	}

	private void SubscribeToEvents()
	{
	}

	public void Dispose()
	{
	}

	public UniTask InitAsync(CancellationToken cancellationToken)
	{
		return default(UniTask);
	}

	private void OnTriggerBoosterTutoZone(BoosterId _type)
	{
	}

	private void TranslateText()
	{
	}

	private void OnTriggeringHint(BoosterId _type)
	{
	}

	private void OnShrinking(bool isShrinking)
	{
	}

	private void OnCurrencyChanged(CurrencyId currencyId, int newAmount)
	{
	}

	private void HandlePricesRefresh()
	{
	}

	private void RefreshInteractable()
	{
	}

	private void RefreshPriceVisibility()
	{
	}

	private void HandleFirstFreeAvailabilityChanged(BoosterId boosterId, bool _)
	{
	}

	private bool IsItAClaimLevel()
	{
		return false;
	}

	private void PulseGlowUntilButtonClick()
	{
	}

	private void StopGlowPulse()
	{
	}

	private void UpdateState()
	{
	}

	private void HandleForcedTutorialPendingChanged()
	{
	}

	private void UpdateNumber()
	{
	}

	private void MarkUnlockStarterRewardClaimed()
	{
	}

	private void HandleCountChanged(BoosterId t, int newCount, bool justClaimed)
	{
	}
}
