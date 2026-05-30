using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using JuicedUp.Core.Bootstrap;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[UsedImplicitly]
	public sealed class LoadingScreenController : IAsyncInitializable
	{
		private const float FadeTime = 0.25f;

		private const float FadeDelay = 0.15f;

		private readonly CanvasGroup _loadingScreen;

		private LoadingDotsAnimator _loadingDotsAnimator;

		private bool _isHidden;

		public bool IsHidden => false;

		public bool IsLoadingScreenHidden => false;

		public event Action LoadingScreenHidden
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public LoadingScreenController(CanvasGroup loadingScreen)
		{
		}

		public UniTask InitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		private void NotifyHidden()
		{
		}
	}
}
