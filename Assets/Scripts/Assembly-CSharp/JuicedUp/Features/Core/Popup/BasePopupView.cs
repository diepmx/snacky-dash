using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Features.Core.Popup
{
	public abstract class BasePopupView : MonoBehaviour
	{
		private const float FadeInDuration = 0.35f;

		[SerializeField]
		protected CanvasGroup _canvasGroup;

		public PopupId Id { get; private set; }

		public event Action<PopupButtonResult> OnResult
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public UniTask ShowAsync(PopupRequest request, CancellationToken ct)
		{
			return default(UniTask);
		}

		public UniTask HideAsync()
		{
			return default(UniTask);
		}

		public virtual void SetInteractable(bool interactable)
		{
		}

		public void ClearListeners()
		{
		}

		protected virtual UniTask OnShowAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		protected virtual UniTask OnHideAsync()
		{
			return default(UniTask);
		}

		protected virtual void OnSetup(IPopupPayload payload)
		{
		}

		protected void ReportResult(PopupButtonResult result)
		{
		}
	}
}
