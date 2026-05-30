using System;
using UnityEngine;

namespace JuicedUp.Features.Shop.Internal.Views
{
	[Serializable]
	internal class BundleTopLayerView
	{
		[field: SerializeField]
		public BundleRewardsContainer RewardContainerPrefab { get; private set; }

		[field: SerializeField]
		public Transform Container { get; private set; }
	}
}
