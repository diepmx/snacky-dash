using System;
using System.Runtime.CompilerServices;
using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.Boosters.Tutorial
{
	public sealed class BoosterTutorialState
	{
		private bool _isCancelBlocked;

		private BoosterId? _forcedTutorialPendingBooster;

		private BoosterId? _activeSpotlightBooster;

		public bool IsCancelBlocked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BoosterId? ForcedTutorialPendingBooster
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BoosterId? ActiveSpotlightBooster
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event Action ForcedTutorialPendingBoosterChanged
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

		public bool IsForcedTutorialPending(BoosterId type)
		{
			return false;
		}

		public bool ShouldSwallowTap(BoosterId tappedType)
		{
			return false;
		}
	}
}
