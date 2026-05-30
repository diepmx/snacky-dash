using System;
using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live
{
	public class DecoratorFactory : IDecoratorFactory<IFeature>, IDisposable
	{
		protected Action<IFeature> _commons;

		protected Dictionary<string, Action<IFeature>> _personas;

		private readonly List<IDisposable> _decoratorsToDispose;

		private bool _disposed;

		public virtual void Dispose()
		{
		}

		public void Register(Action<IFeature> callback, DisposableDecorator decoratorToDispose = null)
		{
		}

		public void Register(string key, Action<IFeature> callback, DisposableDecorator decoratorToDispose = null)
		{
		}

		public void AttachDecorators(IFeature conditionnal)
		{
		}

		public void AttachDecorators(IEnumerable<IFeature> conditionnals)
		{
		}
	}
}
