using JuicedUp.Features.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletionBarUI : MonoBehaviour
{
	[Header("UI")]
	public Slider slider;

	public TextMeshProUGUI label;

	[Header("Behavior")]
	public bool useAbsoluteValues;

	private PillManager _pillManager;

	private CrateManager _crateManager;

	public void Init(CrateManager crateManager, PillManager pillManager)
	{
	}

	private void OnDestroy()
	{
	}

	public void Refresh()
	{
	}

	private void OnLevelBuilt(LevelDataSO _, LevelMeta __)
	{
	}

	private void OnAnyChange(int _)
	{
	}

	private void OnAnyChangePill(Vector3Int _)
	{
	}

	private void OnAnyChangeCrate(PillKind _)
	{
	}
}
