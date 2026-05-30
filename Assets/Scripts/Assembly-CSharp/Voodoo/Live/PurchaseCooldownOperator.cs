using System;

namespace Voodoo.Live
{
	public class PurchaseCooldownOperator : BaseOperator
	{
		private int _cooldownAfterPurchaseInHours;

		public int CooldownInHours => 0;

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
