using JuicedUp.Common.Notifiers.AppLifeCycle;
using JuicedUp.Common.Save;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace JuicedUp.Features.Core
{
	public class RootLifetimeScope : LifetimeScope
	{
		[SerializeField]
		private ES3SaveSettings _es3SaveSettings;

		[SerializeField]
		private AppLifeCycleNotifier _appLifeCycleNotifier;

		[SerializeField]
		private LevelCohortBindings _levelCohortBindings;

		protected override void Configure(IContainerBuilder builder)
		{
		}

		private void RegisterServices(IContainerBuilder builder)
		{
		}

		private static void RegisterDomainRepositories(IContainerBuilder builder)
		{
		}

		private void RegisterStages(IContainerBuilder builder)
		{
		}
	}
}
