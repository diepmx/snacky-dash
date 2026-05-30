using JuicedUp.Features.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PillColorUI : MonoBehaviour
{
	[FormerlySerializedAs("pillColor")]
	public PillKind pillKind;

	public TextMeshProUGUI numberOfPills;

	public Image iconBackGround;

	public Image iconFruit;

	private void Start()
	{
	}

	public void UpdateColor(string _numberOfPills)
	{
	}
}
