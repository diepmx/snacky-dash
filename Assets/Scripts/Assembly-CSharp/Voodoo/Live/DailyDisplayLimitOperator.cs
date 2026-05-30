using System;

namespace Voodoo.Live
{
	public class DailyDisplayLimitOperator : BaseOperator
	{
		private int _capping;

		public override string Key => null;

		protected override Type[] FieldTypes => null;

		protected override bool CastFields(object[] objects, IBlackboard blackboard)
		{
			return false;
		}

		public override bool Evaluate(IBlackboard blackboard)
		{
			return false;
		}

		public override void Validate()
		{
		}
	}
}
