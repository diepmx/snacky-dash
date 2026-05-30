using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Tooltips.Data
{
	public class TooltipPayload
	{
		public readonly TooltipDirection Direction;

		public readonly Vector2 PivotOffset;

		public readonly Transform Parent;

		public readonly IEnumerable<IReward> Rewards;

		public readonly string Text;

		public readonly string AssetKey;

		public Action ClosedCallback { get; set; }

		public TooltipPayload(TooltipDirection direction, Transform parent, string assetKey, IEnumerable<IReward> rewards, string text, Vector2 pivotOffset = default(Vector2))
		{
		}
	}
}
