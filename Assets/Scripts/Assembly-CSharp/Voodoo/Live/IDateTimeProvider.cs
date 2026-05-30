using System;

namespace Voodoo.Live
{
	public interface IDateTimeProvider
	{
		DateTime Now { get; }

		DateTime Today { get; }
	}
}
