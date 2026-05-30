using System;
using System.Collections.Generic;
using VContainer;

namespace JuicedUp.Core.Bootstrap.Builder
{
	public sealed class InitBuilder
	{
		private readonly IContainerBuilder _containerBuilder;

		private readonly List<Type> _sequentialItems;

		private readonly List<Type> _parallelItems;

		private RegistrationBuilder _lastRegistration;

		public InitBuilder(IContainerBuilder containerBuilder)
		{
		}

		public InitBuilder AddSequentialComponent<TImplementation>(TImplementation component, params Type[] types) where TImplementation : IAsyncInitializable
		{
			return null;
		}

		public InitBuilder AddSequential<TImplementation>(Lifetime lifetime = Lifetime.Singleton, params Type[] types) where TImplementation : IAsyncInitializable
		{
			return null;
		}

		public InitBuilder AddParallelComponent<TImplementation>(TImplementation component, params Type[] types) where TImplementation : IAsyncInitializable
		{
			return null;
		}

		public InitBuilder AddParallel<TImplementation>(Lifetime lifetime = Lifetime.Singleton, params Type[] types) where TImplementation : IAsyncInitializable
		{
			return null;
		}

		public InitBuilder AddType<TImplementation>(Lifetime lifetime = Lifetime.Singleton)
		{
			return null;
		}

		public InitBuilder WithParameter<TParam>(TParam value)
		{
			return null;
		}

		public InitBuilder WithParameter(params Type[] value)
		{
			return null;
		}

		public InitBuilder WithParameter(string name, object value)
		{
			return null;
		}

		public InitBuilder As<TImplementation>()
		{
			return null;
		}

		public InitBuilder AsImplementedInterfaces()
		{
			return null;
		}

		public IInitStageDefinition Build(BuildStage stageName)
		{
			return null;
		}
	}
}
