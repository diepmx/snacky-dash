using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Voodoo.Sauce.Internal.Ads.FakeMediation
{
	internal class FakeInterstitialAd : FakeClosableAd
	{
		[FormerlySerializedAs("_closeButton")]
		[SerializeField]
		private Button closeButton;

		protected new void Awake()
		{
		}
	}
}
