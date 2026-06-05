using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Logic controller for the destructible Wall (Blocker) obstacle.
	/// The wall takes damage whenever a crate is delivered.
	/// When HP reaches 0 the wall is destroyed and blocked pill groups are unlocked.
	/// </summary>
	public class WallHealthController : MonoBehaviour
	{
		[SerializeField] private WallView _view;
		[SerializeField] private int _idGroup;
		[SerializeField] private float _delayBeforeDamage = 0.4f;

		private CancellationToken _destroyCancellationToken;
		private PillManager _pillManager;
		private LevelController _levelController;
		private Vector3Int? _blockerCell;
		private int _destructibleWallGroupId;
		private int _destructibleWallHealth;

		// ─── Lifecycle ──────────────────────────────────────────────────────────

		private void OnEnable()
		{
			_destroyCancellationToken = this.GetCancellationTokenOnDestroy();
			LevelBuilder.OnLevelBuilt += OnLevelBuilt;
		}

		private void OnDisable()
		{
			LevelBuilder.OnLevelBuilt -= OnLevelBuilt;

			if (_levelController != null)
			{
				Player.OnArrivedAtCrate -= HandleCrateCompletedByIndex;
			}
		}

		private void OnLevelBuilt(LevelDataSO levelData, LevelMeta _)
		{
			_destructibleWallGroupId = ResolveDestructibleWallGroupId();
			_destructibleWallHealth  = ResolveDestructibleWallHealth(levelData, _destructibleWallGroupId);
			if (_view != null)
				_view.Init(_destructibleWallHealth);
		}

		// ─── Public API ─────────────────────────────────────────────────────────

		public void Init(LevelController levelController, PillManager pillManager, Vector3Int? blockerCell)
		{
			_levelController = levelController;
			_pillManager     = pillManager;
			_blockerCell     = blockerCell;

			// Subscribe to crate delivery events via the Player static event
			Player.OnArrivedAtCrate += HandleCrateCompletedByIndex;
		}

		// ─── Private helpers ────────────────────────────────────────────────────

		private int ResolveDestructibleWallGroupId()
		{
			// Use the serialized _idGroup field as the group ID.
			// If a blocker cell was provided, try to look it up from the level controller.
			if (_blockerCell.HasValue && _levelController != null)
			{
				if (_levelController.TryGetDestructibleWallGroup(
					new Vector2Int(_blockerCell.Value.x, _blockerCell.Value.y),
					out int groupId))
				{
					return groupId;
				}
			}
			return _idGroup;
		}

		private static int ResolveDestructibleWallHealth(LevelDataSO levelData, int groupId)
		{
			if (levelData == null) return 1;
			// Use the level-wide setting (all walls share the same health in this design)
			int hp = levelData.destructibleWallHealth;
			return hp > 0 ? hp : 1;
		}

		private void HandleCrateCompleted(PillKind pillKind)
		{
			if (_destructibleWallHealth <= 0) return;
			TakeDamageAsync().Forget();
		}

		// Adapter for the int-based crate index event
		private void HandleCrateCompletedByIndex(int crateIndex)
		{
			HandleCrateCompleted(PillKind.Strawberry); // kind doesn't matter for wall damage
		}

		private async UniTaskVoid TakeDamageAsync()
		{
			// Wait a brief delay before applying damage (allows crate delivery animation to play)
			await UniTask.Delay(
				System.TimeSpan.FromSeconds(_delayBeforeDamage),
				cancellationToken: _destroyCancellationToken);

			if (_destroyCancellationToken.IsCancellationRequested) return;

			_destructibleWallHealth--;

			if (_view != null)
				_view.HandleDamaged(_destructibleWallHealth);

			if (_destructibleWallHealth <= 0)
				BreakWall();
		}

		private void BreakWall()
		{
			if (_view != null)
				_view.HandleDestroyed();

			UnlockLinkedPillGroups();
		}

		private void UnlockLinkedPillGroups()
		{
			if (_levelController == null) return;

			// Tell the level to restore the path cells blocked by this wall group
			_levelController.RestoreDestructibleWallPath(_destructibleWallGroupId);
		}
	}
}
