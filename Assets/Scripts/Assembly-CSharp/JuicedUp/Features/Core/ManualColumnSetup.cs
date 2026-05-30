using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class ManualColumnSetup
	{
		[Tooltip("Column crates, each with its own color")]
		public List<ManualCrateSetup> crates;
	}
}
