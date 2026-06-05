using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Visual layer for the Turnout (Switch Tube junction) obstacle.
	/// Shows either position A or position B based on the current toggle state.
	/// </summary>
	public class TurnoutView : MonoBehaviour
	{
		[SerializeField] private GameObject _positionA;
		[SerializeField] private GameObject _positionB;

		/// <summary>Initialize visual to match the starting state.</summary>
		public void Init(TurnoutState initialState)
		{
			ShowPosition(initialState);
		}

		/// <summary>Show the visual for the new state, hide the other.</summary>
		public void ShowPosition(TurnoutState newState)
		{
			bool showA = newState == TurnoutState.PositionA;
			if (_positionA != null) _positionA.SetActive(showA);
			if (_positionB != null) _positionB.SetActive(!showA);
		}
	}
}
