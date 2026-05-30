using System;
using JuicedUp.Features.Core.Popup;

namespace JuicedUp.Common.InfoPopup.Data
{
	public class CommonInfoPopupPayload : IPopupPayload
	{
		public readonly string Title;

		public readonly string Message;

		public readonly string GreenButtonText;

		public Action GreenButtonAction;

		public CommonInfoPopupPayload(string title, string message, string greenButtonText, Action greenButtonAction)
		{
		}
	}
}
