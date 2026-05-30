using System;

namespace JuicedUp.Common.Notifiers.AppLifeCycle
{
	public interface IAppLifeCycleNotifier
	{
		event Action<bool> ApplicationFocusChanged;

		event Action<bool> ApplicationPauseChanged;

		event Action ApplicationQuited;

		event Action LateUpdated;
	}
}
