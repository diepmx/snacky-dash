namespace Voodoo.Live
{
	public class VirtualCurrencyPayment : Payment, IPayment, IResultProvider
	{
		public VirtualCurrencyPrice price;

		private readonly IInventory _inventory;

		public VirtualCurrencyPayment(VirtualCurrencyPrice price, IInventory inventory)
		{
		}

		public override void Validate()
		{
		}

		public override bool CanAfford()
		{
			return false;
		}

		public override void Start()
		{
		}
	}
}
