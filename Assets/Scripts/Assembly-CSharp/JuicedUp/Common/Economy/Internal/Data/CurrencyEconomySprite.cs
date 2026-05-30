using System;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Data
{
	[Serializable]
	internal class CurrencyEconomySprite
	{
		[field: SerializeField]
		public CurrencyId Id { get; private set; }

		[field: Space]
		[field: SerializeField]
		public Sprite MainViewSprite { get; private set; }

		[field: SerializeField]
		public Sprite SmallPackSprite { get; private set; }

		[field: SerializeField]
		public Sprite MediumPackSprite { get; private set; }

		[field: SerializeField]
		public Sprite LargePackSprite { get; private set; }

		[field: SerializeField]
		public Sprite ExtraLargePackSprite { get; private set; }

		[field: SerializeField]
		public Sprite XXLPackSprite { get; private set; }

		[field: SerializeField]
		public Sprite ParticleSprite { get; private set; }
	}
}
