using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public abstract class Conditionnal : IConditionnal, IDisposable
	{
		protected IBlackboard _blackboard;

		protected string _errorMessage;

		protected bool _disposed;

		private HashSet<string> OperatorKeys;

		public string ErrorMessage => null;

		public List<string> Tags { get; set; }

		public List<IOperator> Operators { get; protected set; }

		public abstract IBlackboard Blackboard { get; }

		public virtual bool CanUse(List<string> ignoreKeys = null)
		{
			return false;
		}

		public virtual bool AddOperator(IOperator opt)
		{
			return false;
		}

		public virtual bool RemoveOperator(IOperator opt)
		{
			return false;
		}

		public T GetOperator<T>() where T : IOperator
		{
			return default(T);
		}

		public virtual void Dispose()
		{
		}
	}
}
