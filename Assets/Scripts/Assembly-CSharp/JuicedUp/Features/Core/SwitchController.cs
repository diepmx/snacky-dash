using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Lever/Switch kéo cầu (Flipping Bridge) hoặc đổi ngã rẽ (Turnout).
	///
	/// Khi snake head đi vào cell này → toggle state → broadcast đến target group.
	///
	/// _switchBridge  = true → toggle tất cả BridgeController cùng _bridgeGroupId
	/// _switchTurnout = true → toggle tất cả Turnout trong level (Toggle_AllSwitches)
	/// </summary>
	public class SwitchController : MonoBehaviour
	{
		[SerializeField] private SwitchToggleState _initialState;

		[Header("Bridge group — phải khớp với BridgeController._bridgeGroupId")]
		[SerializeField] private bool _switchBridge;
		[SerializeField] private int _bridgeGroupId;

		[FormerlySerializedAs("_switchAiguillage")]
		[SerializeField] private bool _switchTurnout;

		private SwitchToggleState _currentState;
		private SwitchView _view;
		private LevelController _levelController;

		// ─── Lifecycle ────────────────────────────────────────────────────────

		private void OnTriggerEnter2D(Collider2D collision)
		{
			// Chỉ react với snake head
			if (!collision.CompareTag("Player")) return;

			// Toggle state
			_currentState = _currentState == SwitchToggleState.On
				? SwitchToggleState.Off
				: SwitchToggleState.On;

			if (_view != null)
				_view.HandleActivated(_currentState);

			// Broadcast đến các obstacles liên kết
			if (_switchBridge)
			{
				// Chỉ toggle bridges trong cùng group
				BridgeController.ToggleGroup(_bridgeGroupId, _currentState);
			}

			if (_switchTurnout && _levelController != null)
			{
				_levelController.Toggle_AllSwitches();
			}
		}

		// ─── Init ─────────────────────────────────────────────────────────────

		/// <summary>Gọi từ LevelBuilder.</summary>
		public void Init(LevelController levelController)
		{
			_levelController = levelController;
			_currentState    = _initialState;
			_view = GetComponentInChildren<SwitchView>(includeInactive: true);

			if (_view != null)
				_view.Init(_currentState, _levelController);
		}

		public void UpdateSwitchView(SwitchView switchView)
		{
			_view = switchView;
			if (_view != null)
				_view.Init(_currentState, _levelController);
		}
	}
}
