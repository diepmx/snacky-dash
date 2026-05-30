using System;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public interface IInitStageDefinition
	{
		BuildStage Name { get; }

		Type[] SequentialItems { get; }

		Type[] ParallelItems { get; }
	}
}
