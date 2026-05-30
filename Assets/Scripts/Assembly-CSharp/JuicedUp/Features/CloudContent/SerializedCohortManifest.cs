using System;
using System.Collections.Generic;

namespace JuicedUp.Features.CloudContent
{
	[Serializable]
	public class SerializedCohortManifest
	{
		public string cohortName;

		public bool isLoop;

		public int loopStartIndex;

		public List<string> levels;
	}
}
