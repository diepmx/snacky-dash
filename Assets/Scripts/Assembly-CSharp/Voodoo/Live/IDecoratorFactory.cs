using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IDecoratorFactory<T> : IDisposable where T : IConditionnal
	{
		void Register(Action<T> callback, DisposableDecorator disposableDecorator = null);

		void Register(string key, Action<T> callback, DisposableDecorator disposableDecorator = null);

		void AttachDecorators(IEnumerable<T> conditionals);

		void AttachDecorators(T conditional);
	}
}
