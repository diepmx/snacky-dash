using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IOperatorFactory
	{
		void Register(Func<string, IOperator> factory);

		void Process(IEnumerable<Conditionnal> conditionnals);

		void Process(Conditionnal conditionnal);

		IOperator CreateOperator(string value, IBlackboard blackboard);
	}
}
