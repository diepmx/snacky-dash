using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public class NonConsumableOperator : BaseOperator
	{
		private List<string> _itemsNames;

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

		public override void Validate()
		{
		}
	}
}
