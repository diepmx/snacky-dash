using System;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[Serializable]
	public class BoosterEconomySprite
	{
		[field: SerializeField]
		public BoosterId Id { get; private set; }

		[field: SerializeField]
		public Sprite ParticleSprite { get; private set; }

		[field: SerializeField]
		public Sprite HudSprite { get; private set; }
	}
}
