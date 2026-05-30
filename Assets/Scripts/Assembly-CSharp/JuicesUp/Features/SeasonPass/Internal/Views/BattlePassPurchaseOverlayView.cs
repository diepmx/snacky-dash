using System;
using UnityEngine;
using UnityEngine.UI;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassPurchaseOverlayView : BattlePassGenericPopupView
	{
		[Header("Overlay — Fly sources (wire 8-heart and gift-packet)")]
		[SerializeField]
		private Image _heartIconSource;

		[SerializeField]
		private Image _giftIconSource;

		[SerializeField]
		private Transform _heartTarget;

		[Header("Overlay — Optional copy (defaults: empty title, DONE button)")]
		[SerializeField]
		private string _overlayTitle;

		[SerializeField]
		private string _overlayButtonText;

		public Transform HeartTarget => null;

		public Vector3 HeartSourcePosition => default(Vector3);

		public Vector3 GiftSourcePosition => default(Vector3);

		public Sprite HeartSprite => null;

		public Sprite GiftSprite => null;

		public void ShowOverlay(Action onComplete)
		{
		}
	}
}
