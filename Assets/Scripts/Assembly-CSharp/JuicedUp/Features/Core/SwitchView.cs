using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class SwitchView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _meshOn;

		[SerializeField]
		private GameObject _meshOff;

		[SerializeField]
		private bool _canChangePosition;

		[SerializeField]
		private float _wallOffsetLeft;

		[SerializeField]
		private float _wallOffsetRight;

		[SerializeField]
		private float _wallOffsetUp;

		[SerializeField]
		private float _wallOffsetDown;

		private LevelController _levelController;

		public void Init(SwitchToggleState initialState, LevelController levelController)
		{
		}

		public void HandleActivated(SwitchToggleState state)
		{
		}

		public void PushViewIntoNearestWall()
		{
		}

		private bool TryFindWallDirection(Vector2Int cell, out Vector2Int wallDir)
		{
			wallDir = default(Vector2Int);
			return false;
		}
	}
}
