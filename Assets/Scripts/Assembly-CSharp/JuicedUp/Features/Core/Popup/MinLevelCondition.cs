namespace JuicedUp.Features.Core.Popup
{
	public class MinLevelCondition : IPopupCondition
	{
		private readonly int _minLevel;

		public MinLevelCondition(int minLevel)
		{
		}

		public bool IsMet(PopupContext popupContext)
		{
			return false;
		}
	}
}
