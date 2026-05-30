using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live.Offers
{
	public class FeatureQueue : IFeatureQueue, IDisposable
	{
		private readonly Queue<IFeature> _queue;

		private IFeature _currentFeature;

		private bool _isActive;

		public IComparer<IFeature> sortingFunc { get; }

		public bool HasFeatureShown => false;

		public int QueueCount => 0;

		public event Func<IFeature, bool> showFeature
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

		public event Func<IFeature, bool> filteringFunc
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

		public event Action OnQueueBecameActive
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

		public event Action OnQueueBecameIdle
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

		public void Show(List<IFeature> triggeringFeatures)
		{
		}

		private void Show(IFeature feature)
		{
		}

		private void ShowNextFeature()
		{
		}

		private void SetDisplayTime(IFeature feature)
		{
		}

		private void OnFeatureStatusChanged(string status, IFeature feature)
		{
		}

		public void Clear()
		{
		}

		public void Dispose()
		{
		}
	}
}
