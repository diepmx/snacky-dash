namespace Voodoo.Live
{
	public class FreePayment : Payment, IPayment, IResultProvider
	{
		public override bool CanAfford()
		{
			return false;
		}

		public override void Validate()
		{
		}

		public override void Start()
		{
		}
	}
}
