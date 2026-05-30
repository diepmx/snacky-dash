using System;

namespace Voodoo.Live.Offers
{
	[Serializable]
	public class ActiveTimeConfig
	{
		private static readonly TimeSpan ServerEndDay;

		public ActiveTimeType type;

		public TimeSpan from;

		public int duration;

		public TimeSpan to;

		public bool IsEntireDay => false;
	}
}
