using System;

namespace Voodoo.Live
{
	public class CountdownOperator : BaseOperator, ICountdownProvider
	{
		private TimeSpan _countdown;

		private DateTime _countdownStart;

		public override string Key => null;

		protected override Type[] FieldTypes => null;

		protected override bool CastFields(object[] objects, IBlackboard blackboard)
		{
			return false;
		}

		public TimeSpan TimeLeft()
		{
			return default(TimeSpan);
		}

		public override bool Evaluate(IBlackboard parameters)
		{
			return false;
		}

		public override void Validate()
		{
		}
	}
}
