using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class RisingBlockView : MonoBehaviour
	{
		[Header("Animations")]
		[SerializeField]
		private float _duration;

		[SerializeField]
		private Vector3 _open;

		[SerializeField]
		private Vector3 _closed;

		[FormerlySerializedAs("_meshR")]
		[Header("Visuals")]
		[SerializeField]
		private GameObject _mesh;

		[SerializeField]
		private ParticleSystem _blockLowerParticleSystem;

		[Header("Debug Gizmos")]
		[SerializeField]
		private bool _drawCoveredCellsGizmos;

		[SerializeField]
		private bool _autoRecomputeInEditor;

		[SerializeField]
		private Color _gizmoCellsColor;

		[SerializeField]
		private Color _gizmoOutlineColor;

		private readonly List<Vector3Int> _coveredCells;

		private Collider2D _blockCollider;

		public void SetCoveredCells(List<Vector3Int> cells, Collider2D blockCollider)
		{
		}

		public void Init()
		{
		}

		public void SnapState(bool open)
		{
		}

		public void AnimateState(bool open, bool playSound)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void TryCacheCoveredCellsEditorSafe()
		{
		}

		private void CacheCoveredCells()
		{
		}

		private void DrawCellsGizmos()
		{
		}
	}
}
