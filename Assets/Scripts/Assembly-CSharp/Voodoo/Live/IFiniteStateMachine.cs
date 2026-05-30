using System;

namespace Voodoo.Live
{
	public interface IFiniteStateMachine
	{
		string Status { get; }

		event Action<string, IFiniteStateMachine> statusChanged;

		void SetStatus(string status);
	}
}
