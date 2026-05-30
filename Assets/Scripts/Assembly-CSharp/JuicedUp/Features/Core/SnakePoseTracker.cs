using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class SnakePoseTracker : MonoBehaviour
	{
		private const int MaxPosHistory = 300;

		private readonly List<PositionStateRotation> _queue;

		public IReadOnlyList<PositionStateRotation> Queue => null;

		public static event Action<IReadOnlyList<PositionStateRotation>, Player> OnSnakePoseUpdated
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

		public void Push(Vector3 position, Quaternion rotation, State state, DirectionPlayer direction, Player player)
		{
		}

		public void Init(Transform head, State state, DirectionPlayer direction, Player player)
		{
		}

		private void Trim()
		{
		}
	}
}
