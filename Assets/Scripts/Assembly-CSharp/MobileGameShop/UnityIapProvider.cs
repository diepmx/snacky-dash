using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace MobileGameShop
{
	public class UnityIapProvider : MonoBehaviour, IIapProvider
	{
		private class Listener : IStoreListener
		{
			private readonly UnityIapProvider _owner;

			private readonly Action<bool, string> _onDone;

			public Listener(UnityIapProvider owner, Action<bool, string> onDone)
			{
			}

			public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
			{
			}

			public void OnInitializeFailed(InitializationFailureReason error)
			{
			}

			public void OnInitializeFailed(InitializationFailureReason error, string message)
			{
			}

			public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
			{
				return default(PurchaseProcessingResult);
			}

			public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
			{
			}
		}

		[SerializeField]
		private Button purchaseButton;

		private bool _initialized;

		private IStoreController _controller;

		private IExtensionProvider _extensions;

		private Action<PurchaseResult> _pendingPurchase;

		private readonly Dictionary<string, string> _cachedPrices;

		public bool IsInitialized => false;

		private void Start()
		{
		}

		private void PurchaseTheProduct()
		{
		}

		private void OnDestroy()
		{
		}

		public void Initialize(IEnumerable<string> productIds, Action<bool, string> onDone)
		{
		}

		public string GetLocalizedPrice(string productId)
		{
			return null;
		}

		public void Purchase(string productId, Action<PurchaseResult> onDone)
		{
		}

		public void Restore(Action<bool, string> onDone)
		{
		}

		public bool HasReceipt(string productId)
		{
			return false;
		}
	}
}
