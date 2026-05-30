using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public class OperatorFactory : IOperatorFactory
	{
		private readonly List<Func<string, IOperator>> _registries;

		public void Register(Func<string, IOperator> factory)
		{
		}

		public void Process(IEnumerable<Conditionnal> conditionnals)
		{
		}

		public void Process(Conditionnal conditionnal)
		{
		}

		public IOperator CreateOperator(string value, IBlackboard blackboard)
		{
			return null;
		}

		private void ParseFunctionCall(string value, out string key, out string[] parameters)
		{
			key = null;
			parameters = null;
		}
	}
}
