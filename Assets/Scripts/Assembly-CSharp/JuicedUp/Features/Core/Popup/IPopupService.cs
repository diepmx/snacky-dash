using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Features.Core.Popup
{
	public interface IPopupService
	{
		int ActivePopupCount { get; }

		bool HasAnyActivePopup { get; }

		event Action<PopupId> OnPopupShown;

		event Action<PopupId> OnPopupHidden;

		UniTask<PopupButtonResult> ShowAsync(PopupId id, bool fadeIn = false, PopupPriority priority = PopupPriority.Normal, IPopupPayload payload = null);

		UniTask<PopupButtonResult> HideAsync(PopupId id);

		void DestroyPopup(PopupId id, float delaySeconds = 0f);

		void Enqueue(PopupRequest request);

		bool IsShowing(PopupId id);

		bool IsQueued(PopupId id);

		bool WasShownRecently(PopupId id, float withinSeconds);

		IReadOnlyList<PopupHistoryEntry> GetHistory();

		void RegisterScheduled(ScheduledPopupEntry entry);

		void UnregisterScheduled(PopupId id);

		void EvaluateScheduled(PopupContext ctx);

		void EvaluateBestScheduled(PopupContext ctx);
	}
}
