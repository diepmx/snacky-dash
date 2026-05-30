using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHintBooster : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public BoosterId boosterType;

	[SerializeField]
	private GameObject rootToClose;

	[SerializeField]
	[Tooltip("Hidden while the forced booster tutorial holds the player hostage. Wire to the Cancel/Close Button GameObject inside this prefab. Optional - leave null on prefabs that have no cancel button.")]
	private GameObject _closeButton;

	[SerializeField]
	[Tooltip("Shown ONLY while the forced booster tutorial is active (BoosterManager.instance.IsCancelBlocked). Wire to a designer-authored arrow GameObject (with a BoosterTutorialArrowBob for animation) inside this prefab. Currently used for Tunnel placement guidance. Optional - leave null on prefabs that don't need a placement arrow.")]
	private GameObject _tutorialArrow;

	private SwipeController swipeController;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void ClosePanel()
	{
	}

	private void HandleCancelBoosterFocus(BoosterId type)
	{
	}

	public void OpenPanel()
	{
	}
}
