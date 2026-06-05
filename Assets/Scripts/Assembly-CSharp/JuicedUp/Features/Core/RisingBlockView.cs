using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Visual layer for the Rising Block (Bollard) obstacle.
	/// Animates between open (lowered) and closed (raised) positions.
	/// </summary>
	public class RisingBlockView : MonoBehaviour
	{
		[Header("Animations")]
		[SerializeField] private float _duration = 0.4f;
		[SerializeField] private Vector3 _open   = new Vector3(0f, -1f, 0f);   // lowered position (local)
		[SerializeField] private Vector3 _closed = new Vector3(0f, 0f, 0f);    // raised position (local)

		[FormerlySerializedAs("_meshR")]
		[Header("Visuals")]
		[SerializeField] private GameObject _mesh;
		[SerializeField] private ParticleSystem _blockLowerParticleSystem;

		[Header("Debug Gizmos")]
		[SerializeField] private bool _drawCoveredCellsGizmos;
		[SerializeField] private bool _autoRecomputeInEditor;
		[SerializeField] private Color _gizmoCellsColor   = new Color(1f, 0.3f, 0.3f, 0.4f);
		[SerializeField] private Color _gizmoOutlineColor = new Color(1f, 0.2f, 0.2f, 0.9f);

		private readonly List<Vector3Int> _coveredCells = new List<Vector3Int>();
		private Collider2D _blockCollider;
		private Tweener _currentTween;

		// ─── Setup ───────────────────────────────────────────────────────────────

		/// <summary>Cache the covered cells list from the controller.</summary>
		public void SetCoveredCells(List<Vector3Int> cells, Collider2D blockCollider)
		{
			_coveredCells.Clear();
			if (cells != null)
				_coveredCells.AddRange(cells);
			_blockCollider = blockCollider;
		}

		/// <summary>Initialize the view in its default state (closed/raised).</summary>
		public void Init()
		{
			if (_mesh != null)
				_mesh.SetActive(true);

			transform.localPosition = _closed;
		}

		// ─── State transitions ────────────────────────────────────────────────

		/// <summary>Immediately snap to open (lowered) or closed (raised) position.</summary>
		public void SnapState(bool open)
		{
			_currentTween?.Kill();
			Vector3 target = open ? _open : _closed;
			transform.localPosition = target;

			if (_mesh != null)
				_mesh.SetActive(!open); // mesh hidden when lowered (open)
		}

		/// <summary>Animate to open (lowered) or closed (raised) position.</summary>
		public void AnimateState(bool open, bool playSound)
		{
			_currentTween?.Kill();
			Vector3 target = open ? _open : _closed;

			_currentTween = transform
				.DOLocalMove(target, _duration)
				.SetEase(open ? Ease.OutBounce : Ease.InBack)
				.OnComplete(() =>
				{
					if (_mesh != null)
						_mesh.SetActive(!open);

					// Play particle when lowering (opening)
					if (open && _blockLowerParticleSystem != null)
					{
						_blockLowerParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
						_blockLowerParticleSystem.Play();
					}
				});
		}

		// ─── Gizmos ──────────────────────────────────────────────────────────

		private void OnDrawGizmosSelected()
		{
			if (!_drawCoveredCellsGizmos) return;

			if (_autoRecomputeInEditor)
				TryCacheCoveredCellsEditorSafe();

			DrawCellsGizmos();
		}

		private void TryCacheCoveredCellsEditorSafe()
		{
#if UNITY_EDITOR
			CacheCoveredCells();
#endif
		}

		private void CacheCoveredCells()
		{
			_coveredCells.Clear();
			if (_blockCollider == null) return;

			Bounds bounds = _blockCollider.bounds;
			int minX = Mathf.FloorToInt(bounds.min.x);
			int maxX = Mathf.FloorToInt(bounds.max.x);
			int minY = Mathf.FloorToInt(bounds.min.y);
			int maxY = Mathf.FloorToInt(bounds.max.y);

			for (int x = minX; x <= maxX; x++)
				for (int y = minY; y <= maxY; y++)
					_coveredCells.Add(new Vector3Int(x, y, 0));
		}

		private void DrawCellsGizmos()
		{
			foreach (Vector3Int cell in _coveredCells)
			{
				Vector3 center = new Vector3(cell.x + 0.5f, cell.y + 0.5f, 0f);
				Gizmos.color = _gizmoCellsColor;
				Gizmos.DrawCube(center, Vector3.one * 0.9f);
				Gizmos.color = _gizmoOutlineColor;
				Gizmos.DrawWireCube(center, Vector3.one * 0.9f);
			}
		}
	}
}
