using System;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public struct InitStageDefinition : IInitStageDefinition
	{
		public BuildStage Name { get; }

		public Type[] SequentialItems { get; }

		public Type[] ParallelItems { get; }

		public InitStageDefinition(BuildStage name, Type[] sequentialItems, Type[] parallelItems)
		{
			Name = default(BuildStage);
			SequentialItems = null;
			ParallelItems = null;
		}
	}
}
