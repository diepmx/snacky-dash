using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class TunnelTraversalHandler : MonoBehaviour
	{
		private TailManager _tailManager;

		private PlayerView _view;

		public static event Action<bool> OnEnterTunnel
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<bool> OnExitTunnel
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Init(PlayerView view, TailManager tailManager)
		{
		}

		public void Traverse(Transform playerTransform, Vector3 exitWorld, Vector3Int exitCell, bool continueAfterExit, Func<State> getState, Action<State> setState, Func<DirectionPlayer> getDirection, Action<DirectionPlayer> setDirection, SnakePoseTracker poseTracker, Player player, Action<DirectionPlayer> onContinueMovement, Action<bool> setIsMoving, bool isBoosterTunnel = false, Action<Vector3Int> onSyncArrivalCell = null)
		{
		}
	}
}
