namespace JuicedUp.Features.Core.Popup
{
	public class MaxShowsPerSessionCondition : IPopupCondition
	{
		private readonly PopupId _popupId;

		private readonly int _maxShows;

		public MaxShowsPerSessionCondition(PopupId popupId, int maxShows)
		{
		}

		public bool IsMet(PopupContext popupContext)
		{
			return false;
		}
	}
}
