using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;
using Voodoo.Live.Utils;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class OfferBadgeUI : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _badgeImg;

		[SerializeField]
		private Countdown _countdown;

		[SerializeField]
		private TextMeshProUGUI _offerNameTxt;

		private IFeature _feature;

		private string _offerSourceValue;

		public IFeature Feature => null;

		public void Init(IFeature feature, string source)
		{
		}

		private void SetupCountdown()
		{
		}

		private void BadgeClicked()
		{
		}

		private void OnStatusChanged(string status, IFeature feature)
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		public void ShowBadge()
		{
		}

		private void Hide()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
