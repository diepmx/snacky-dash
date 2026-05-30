using System;

namespace Voodoo.Live
{
	public abstract class BaseOperator : IOperator, IResultProvider<OperatorMountResult>
	{
		protected OperatorMountResult _mountResult;

		protected string _evaluationErrorMessage;

		public abstract string Key { get; }

		protected abstract Type[] FieldTypes { get; }

		public string ErrorMessage => null;

		public OperatorMountResult Validation => null;

		public abstract bool Evaluate(IBlackboard parameters);

		public void Mount(string[] parameters, IBlackboard blackboard)
		{
		}

		private object[] ResolveParameters(string[] parameters, IBlackboard blackboard)
		{
			return null;
		}

		protected abstract bool CastFields(object[] objects, IBlackboard blackboard);

		public abstract void Validate();
	}
}
