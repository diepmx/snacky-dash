using System;

namespace JuicedUp.Common.MilestoneProgressbar.Handlers
{
	public interface IProgressbarValueHandler
	{
		float StartProgressbarValue { get; }

		event Action<float, float> ProgressbarValueChangeRequested;

		void Activate();

		void Deactivate();
	}
}
