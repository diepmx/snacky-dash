using System;

namespace Voodoo.Live
{
	public class DefaultDateTimeProvider : IDateTimeProvider
	{
		public DateTime Now => default(DateTime);

		public DateTime Today => default(DateTime);
	}
}
