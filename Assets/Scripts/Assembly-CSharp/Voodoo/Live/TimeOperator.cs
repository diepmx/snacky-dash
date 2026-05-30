using System;

namespace Voodoo.Live
{
	public class TimeOperator : BaseOperator
	{
		private TimeEvent _timeEvent;

		public TimeEvent TimeEvent => null;

		public override string Key => null;

		protected override Type[] FieldTypes => null;

		protected override bool CastFields(object[] objects, IBlackboard blackboard)
		{
			return false;
		}

		private TimeEventRecurrence ParseRecurrence(object[] objects)
		{
			return null;
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
