using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrateColumnSideUI : MonoBehaviour
{
	public RectTransform rect;

	public Image[] icons;

	[Header("Box count labels (same size/order as icons)")]
	public TextMeshProUGUI[] boxTexts;

	public void SetIcons(IReadOnlyList<CratePreviewItem> items)
	{
	}
}
