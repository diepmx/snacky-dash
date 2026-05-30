namespace JuicedUp.Features.Core.Popup
{
	public class LivesBelowCondition : IPopupCondition
	{
		private readonly int _threshold;

		public LivesBelowCondition(int threshold)
		{
		}

		public bool IsMet(PopupContext popupContext)
		{
			return false;
		}
	}
}
