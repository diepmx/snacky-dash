using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class SwitchController : MonoBehaviour
	{
		[SerializeField]
		private SwitchToggleState _initialState;

		[SerializeField]
		private bool _switchBridge;

		[FormerlySerializedAs("_switchAiguillage")]
		[SerializeField]
		private bool _switchTurnout;

		private SwitchToggleState _currentState;

		private SwitchView _view;

		private Transform _transform;

		private LevelController _levelController;

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}

		public void Init(LevelController levelController)
		{
		}

		private void InitSwitchCrossRoadView()
		{
		}

		public void UpdateSwitchView(SwitchView switchView)
		{
		}
	}
}
