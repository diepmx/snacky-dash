using System;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Views
{
	[Serializable]
	public class RewardsContainer
	{
		[SerializeField]
		private int _maximumRewardsCount;

		[field: SerializeField]
		public Transform RewardContainer { get; private set; }

		public bool IsFree()
		{
			return false;
		}
	}
}
