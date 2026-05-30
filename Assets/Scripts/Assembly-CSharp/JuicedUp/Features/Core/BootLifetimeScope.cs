using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace JuicedUp.Features.Core
{
	public class BootLifetimeScope : LifetimeScope
	{
		[SerializeField]
		private CanvasGroup _loadingScreenCanvasGroup;

		protected override void Configure(IContainerBuilder builder)
		{
		}

		private void RegisterStages(IContainerBuilder builder)
		{
		}
	}
}
