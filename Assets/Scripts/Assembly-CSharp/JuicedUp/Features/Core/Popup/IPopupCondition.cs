namespace JuicedUp.Features.Core.Popup
{
	public interface IPopupCondition
	{
		bool IsMet(PopupContext popupContext);
	}
}
