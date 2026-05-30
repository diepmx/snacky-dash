using System;

namespace Voodoo.Live
{
	public class SpinOperator : BaseOperator
	{
		public override string Key => null;

		protected override Type[] FieldTypes => null;

		protected override bool CastFields(object[] objects, IBlackboard blackboard)
		{
			return false;
		}

		public override bool Evaluate(IBlackboard parameters)
		{
			return false;
		}

		public void Reset(IBlackboard blackboard)
		{
		}

		public override void Validate()
		{
		}
	}
}
