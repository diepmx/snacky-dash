using System;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class ResetCampaignsButton : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Button _resetBtn;

		public static Action OnResetCampaigns;

		private void Start()
		{
		}

		private void ResetCampaigns()
		{
		}
	}
}
