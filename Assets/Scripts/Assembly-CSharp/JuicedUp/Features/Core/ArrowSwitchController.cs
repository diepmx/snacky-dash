using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class ArrowSwitchController : MonoBehaviour, IPairedArrow
	{
		[SerializeField]
		private ArrowView _view;

		[FormerlySerializedAs("arrowDirection")]
		[Header("Config — assign in prefab Inspector")]
		public ArrowDirection _arrowDirection;

		[FormerlySerializedAs("isFixedArrow")]
		public bool IsFixedArrow;

		[FormerlySerializedAs("switchID")]
		public int SwitchID;

		public bool IsUnique;

		[FormerlySerializedAs("positionArrow")]
		[Header("Runtime — set by Init()")]
		public Vector3Int PositionArrow;

		Vector3Int IPairedArrow.PositionArrow => default(Vector3Int);

		private void OnDisable()
		{
		}

		private void OnReviveOver()
		{
		}

		public void Init(Vector3Int cellPos)
		{
		}

		public void InverseDirection()
		{
		}

		public void PlayNotAllowedAnimation()
		{
		}

		public void OpenGate()
		{
		}

		private void CloseGate()
		{
		}

		public bool IsDirectionPlayerSameAsArrow(DirectionPlayer direction)
		{
			return false;
		}

		private void HandleTipLiveCell(Vector3Int cell, TileType type)
		{
		}
	}
}
