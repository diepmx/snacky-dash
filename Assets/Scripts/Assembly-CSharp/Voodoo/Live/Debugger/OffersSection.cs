using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Debugger
{
	public class OffersSection : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private OffersSubHeader _subHeader;

		[SerializeField]
		private OffersSubHeader _invalidOffers;

		[SerializeField]
		private Transform _contentTransform;

		[SerializeField]
		private Transform _contentInvalidTransform;

		[SerializeField]
		private TextMeshProUGUI _offersUrlTXT;

		[SerializeField]
		private Button _offersUrlCopyBtn;

		[SerializeField]
		private Button _serverDataCopyBtn;

		[SerializeField]
		private TriggersSection _triggersSection;

		[Header("Reload State")]
		[SerializeField]
		private TextMeshProUGUI _reloadStateTxt;

		[SerializeField]
		private TextMeshProUGUI _blockersTxt;

		[SerializeField]
		private TextMeshProUGUI _lastRequestInfoTxt;

		[SerializeField]
		private TextMeshProUGUI _lastReloadAppliedTxt;

		private FeatureClient _offersManager;

		public void Init(FeatureClient offersManager)
		{
		}

		private void Update()
		{
		}

		private void PopulateReloadState(FeatureClient offersManager)
		{
		}

		private void CopyOffersUrl(FeatureClient offersManager)
		{
		}

		private void CopyServerData(FeatureClient offersManager)
		{
		}
	}
}
