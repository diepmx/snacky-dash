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
		}
	}
}
