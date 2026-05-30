using System;

namespace Voodoo.Live
{
	public interface ICountdownProvider
	{
		TimeSpan TimeLeft();
	}
}
