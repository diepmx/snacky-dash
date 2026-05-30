using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public class TutorialView : MonoBehaviour
{
	public static TutorialView instance;

	public List<GameObject> tutoLevelOne;

	public GameObject hand;

	public GameObject tapToContinue;

	private int indexAlreadyShown;

	private PillManager _pillManager;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void TrySubscribeFirstPillTutorial()
	{
	}

	private void UnsubscribeFirstPillTutorial()
	{
	}

	private void OnFirstPillCollectedShowSwipeTutorial(Vector3Int _)
	{
	}

	public void ShowTutorial(int index)
	{
	}

	public void ForceShowTutorial(int index)
	{
	}

	private void ShowTutorialInternal(int index, bool allowWhenForcedTutorialActive)
	{
	}

	public void HideHand()
	{
	}

	public void HideAllVisuals()
	{
	}
}
