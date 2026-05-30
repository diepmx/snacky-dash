using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Debugger
{
	public class TriggerButton : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TextMeshProUGUI _btnTriggerTxt;

		[SerializeField]
		private TextMeshProUGUI _btnFrequencyTxt;

		[SerializeField]
		private Button _triggerBtn;

		private int _triggerCount;

		private string _appEvent;

		private FeatureClient _offersManager;

		public void Init(string appEvent, FeatureClient offersManager, IFeature feature)
		{
		}

		private void SetFrequencyText(string appEvent)
		{
		}

		private void OnClick(FeatureClient offersManager)
		{
		}

		private void OnResetOffers()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
