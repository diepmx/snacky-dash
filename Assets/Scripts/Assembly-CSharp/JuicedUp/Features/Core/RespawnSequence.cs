using System;
using System.Collections.Generic;
using EasyButtons;

namespace JuicedUp.Features.Core
{
	[Serializable]
	public class RespawnSequence
	{
		public List<RespawnBatch> batches;

		public int grandTotal;

		[Button("Calculate Grand Total SPAWN")]
		public void CalculateGrandTotal()
		{
		}
	}
}
