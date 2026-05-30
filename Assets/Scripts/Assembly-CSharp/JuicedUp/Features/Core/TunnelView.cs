using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TunnelView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _tunnelEntrance;

		[SerializeField]
		private GameObject _tunnelExit;

		public GameObject TunnelEntrance => null;

		public GameObject TunnelExit => null;

		public void HideEntrance()
		{
		}

		public void HideExit()
		{
		}
	}
}
