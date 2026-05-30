using System;
using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Features.Boosters.PreUseAnimation
{
	public class BoosterTrailRegistry : MonoBehaviour
	{
		[Serializable]
		private struct Entry
		{
			public BoosterId BoosterId;

			public Transform TrailRoot;
		}

		[Tooltip("One entry per booster that should play a trail. Boosters not listed here will skip the pre-use animation and fall back to legacy flow.")]
		[SerializeField]
		private List<Entry> _entries;

		public bool TryGetTrail(BoosterId boosterId, out Transform trailRoot)
		{
			trailRoot = null;
			return false;
		}
	}
}
