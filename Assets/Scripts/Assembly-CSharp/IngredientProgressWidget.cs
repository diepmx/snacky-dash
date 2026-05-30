using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientProgressWidget : MonoBehaviour
{
	[Header("Root")]
	public GameObject root;

	[Header("Visuals")]
	public Image silhouetteDark;

	public Image silhouetteFill;

	public TMP_Text percentText;

	[Header("Optional labels")]
	public TMP_Text titleText;

	[Header("Animation")]
	[Min(0.05f)]
	public float fillDuration;

	public Ease fillEase;

	[Min(0.05f)]
	public float completePunchDuration;

	public float completePunchStrength;

	public bool animateUnscaledTime;

	private Tween _completeTween;

	private Tween _fillTween;

	private Tween _pctTween;

	public void Hide()
	{
	}

	public void Show(Sprite icon, float from01, float to01, bool unlockedNow, bool playCompleteAnim)
	{
	}

	private void KillTweens()
	{
	}

	private void PlayCompleteAnim()
	{
	}
}
