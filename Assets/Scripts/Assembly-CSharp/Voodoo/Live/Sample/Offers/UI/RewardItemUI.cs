using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class RewardItemUI : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TextMeshProUGUI _rewardAmountText;

		[SerializeField]
		private Image _rewardIcon;

		public void Setup(string rewardAmount, Sprite rewardIcon)
		{
		}
	}
}
