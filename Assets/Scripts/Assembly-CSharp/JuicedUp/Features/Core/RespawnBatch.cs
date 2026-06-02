using System;
using System.Collections.Generic;
using EasyButtons;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class RespawnBatch
	{
		public List<RespawnColorCount> colors;

		public int total;

		[Button("Calculate Total")]
		public void CalculateTotal()
		{
			total = 0;
			if (colors != null)
				foreach (RespawnColorCount c in colors)
					if (c != null) total += c.count;
		}
	}
}
