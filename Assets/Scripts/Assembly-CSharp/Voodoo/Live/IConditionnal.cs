using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IConditionnal : IDisposable
	{
		List<IOperator> Operators { get; }

		IBlackboard Blackboard { get; }

		string ErrorMessage { get; }

		bool CanUse(List<string> ignoreKeys = null);

		bool AddOperator(IOperator opt);

		bool RemoveOperator(IOperator opt);

		T GetOperator<T>() where T : IOperator;
	}
}
