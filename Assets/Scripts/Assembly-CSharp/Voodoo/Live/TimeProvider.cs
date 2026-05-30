using System;

namespace Voodoo.Live
{
	public static class TimeProvider
	{
		private static IDateTimeProvider _current;

		public static IDateTimeProvider Current
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DateTime Now => default(DateTime);

		public static DateTime Today => default(DateTime);
	}
}
