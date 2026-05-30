using System;
using VContainer;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public static class LifetimeScopeBuilderExtensions
	{
		public static void RegisterStage(this IContainerBuilder builder, BuildStage stage, Action<InitBuilder> configure)
		{
		}

		private static void RegisterStageDefinition(IContainerBuilder builder, IInitStageDefinition initStageDefinition)
		{
		}
	}
}
