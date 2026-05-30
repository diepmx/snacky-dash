using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public abstract class DisposableDecorator : IDisposable
	{
		protected readonly List<IFeature> _appliedFeatures;

		protected bool _disposed;

		public virtual void Apply(IFeature feature)
		{
		}

		protected abstract void OnStatusChanged(string status, IFeature feature);

		public virtual void Remove(IFeature feature)
		{
		}

		public virtual void Dispose()
		{
		}
	}
}
