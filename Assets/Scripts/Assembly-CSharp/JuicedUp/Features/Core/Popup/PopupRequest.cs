using System.Threading;

namespace JuicedUp.Features.Core.Popup
{
	public readonly struct PopupRequest
	{
		public PopupId Id { get; }

		public PopupPriority Priority { get; }

		public IPopupPayload Payload { get; }

		public CancellationToken CancellationToken { get; }

		public bool FadeIn { get; }

		public PopupRequest(PopupId id, PopupPriority priority = PopupPriority.Normal, IPopupPayload payload = null, bool fadeIn = true, CancellationToken cancellationToken = default(CancellationToken))
		{
			Id = default(PopupId);
			Priority = default(PopupPriority);
			Payload = null;
			CancellationToken = default(CancellationToken);
			FadeIn = false;
		}
	}
}
