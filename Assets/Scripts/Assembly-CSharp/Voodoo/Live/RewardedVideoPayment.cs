namespace Voodoo.Live
{
	public class RewardedVideoPayment : Payment, IPayment, IResultProvider
	{
		public RewardedVideoPrice price;

		public int RVLeft;

		public string Type => null;

		public RewardedVideoPayment(RewardedVideoPrice price)
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

		private void OnRVComplete(bool watchedEntirely)
		{
		}
	}
}
