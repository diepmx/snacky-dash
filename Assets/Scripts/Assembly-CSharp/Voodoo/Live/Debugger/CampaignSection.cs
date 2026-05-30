using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Debugger
{
	public class CampaignSection : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private CampaignSubHeader _campaignSubHeader;

		[SerializeField]
		private TextMeshProUGUI _campaignsUrlTXT;

		[SerializeField]
		private Button _campaignsUrlCopyBtn;

		[SerializeField]
		private Button _serverDataCopyBtn;

		[SerializeField]
		private Transform _contentTransform;

		public void Init(FeatureClient featureClient)
		{
		}

		private void CopyCampaignsUrl(FeatureClient featureClient)
		{
		}

		private void CopyCampaignsData(FeatureClient featureClient)
		{
		}
	}
}
