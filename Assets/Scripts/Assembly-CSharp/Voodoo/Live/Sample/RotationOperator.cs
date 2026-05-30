using System;

namespace Voodoo.Live.Sample
{
	public class RotationOperator : BaseOperator
	{
		private int _rotationIndex;

		private int _rotationCount;

		private RotationRecurrance _recurrance;

		public override string Key => null;

		protected override Type[] FieldTypes => null;

		public override bool Evaluate(IBlackboard parameters)
		{
			return false;
		}

		public int GetCurrentRotation(TimeSpan timePast)
		{
			return 0;
		}

		public bool IsInRotation(TimeSpan timePast)
		{
			return false;
		}

		protected override bool CastFields(object[] objects, IBlackboard blackboard)
		{
			return false;
		}

		public override void Validate()
		{
		}
	}
}
