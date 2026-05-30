using System;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public struct DestructibleWallGroupHealth
	{
		public int groupId;

		public Vector2Int seedCell;

		public int cellCount;

		public int health;
	}
}
