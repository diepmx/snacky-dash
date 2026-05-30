namespace JuicedUp.Features.Core.Popup
{
	public readonly struct PopupButtonResult
	{
		public PopupId PopupId { get; }

		public PopupAction Action { get; }

		public object Context { get; }

		public bool HidePopup { get; }

		public bool DestroyOnHide { get; }

		public PopupButtonResult(PopupId popupId, PopupAction action, bool hidePopup = true, bool destroyOnHide = true, object context = null)
		{
			PopupId = default(PopupId);
			Action = default(PopupAction);
			Context = null;
			HidePopup = false;
			DestroyOnHide = false;
		}
	}
}
