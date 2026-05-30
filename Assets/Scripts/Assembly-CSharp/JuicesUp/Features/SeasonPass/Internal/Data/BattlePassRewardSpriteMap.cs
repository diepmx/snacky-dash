using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Data
{
	[CreateAssetMenu(fileName = "BattlePassRewardSpriteMap", menuName = "Engine/SeasonPass/Reward Sprite Map", order = 0)]
	internal class BattlePassRewardSpriteMap : ScriptableObject
	{
		[Serializable]
		internal class RewardSpriteEntry
		{
			[SerializeField]
			private string _rewardName;

			[SerializeField]
			private Sprite _sprite;

			public string RewardName => null;

			public Sprite Sprite => null;
		}

		[SerializeField]
		private List<RewardSpriteEntry> _entries;

		public Sprite GetSprite(string rewardName)
		{
			return null;
		}
	}
}
