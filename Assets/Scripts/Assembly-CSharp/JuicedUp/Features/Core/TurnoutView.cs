using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TurnoutView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _positionA;

		[SerializeField]
		private GameObject _positionB;

		public void Init(TurnoutState initialState)
		{
		}

		public void ShowPosition(TurnoutState newState)
		{
		}
	}
}
