using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TunnelView : MonoBehaviour
	{
		[SerializeField] private GameObject _tunnelEntrance;
		[SerializeField] private GameObject _tunnelExit;

		public GameObject TunnelEntrance => _tunnelEntrance;
		public GameObject TunnelExit => _tunnelExit;

		/// <summary>Hide the tunnel entrance cap (snake has entered).</summary>
		public void HideEntrance()
		{
			if (_tunnelEntrance != null)
				_tunnelEntrance.SetActive(false);
		}

		/// <summary>Hide the tunnel exit cap (snake tail is still inside).</summary>
		public void HideExit()
		{
			if (_tunnelExit != null)
				_tunnelExit.SetActive(false);
		}

		/// <summary>Show both entrance and exit caps (snake is clear).</summary>
		public void ShowAll()
		{
			if (_tunnelEntrance != null)
				_tunnelEntrance.SetActive(true);
			if (_tunnelExit != null)
				_tunnelExit.SetActive(true);
		}
	}
}
