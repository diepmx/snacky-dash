using System;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public struct NamedCrateVisualConfigVariant
	{
		public string Key;

		public CrateVisualConfig Config;
	}
}
