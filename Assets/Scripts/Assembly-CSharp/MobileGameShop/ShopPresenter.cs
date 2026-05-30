using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MobileGameShop
{
	public class ShopPresenter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCollectProductIds_003Ed__25 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private ShopCatalogSO c;

			public ShopCatalogSO _003C_003E3__c;

			private List<ShopSectionSO>.Enumerator _003C_003E7__wrap1;

			private List<ShopOfferSO>.Enumerator _003C_003E7__wrap2;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCollectProductIds_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Header("Catalog")]
		public ShopCatalogSO catalog;

		[Header("UI")]
		public ShopView view;

		[Header("IAP Provider")]
		public MonoBehaviour iapProviderBehaviour;

		private IIapProvider _iap;

		[Header("Default Services (PlayerPrefs)")]
		public bool useDefaultPlayerPrefsServices;

		public IShopContext Context { get; private set; }

		public event Action<string> OnPurchaseSucceeded
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

		public event Action<string> OnPurchaseFailed
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void InitializeIapThenRefresh()
		{
		}

		public void Refresh()
		{
		}

		public List<ShopSectionVM> BuildViewModels()
		{
			return null;
		}

		private bool IsOfferOwned(ShopOfferSO offer)
		{
			return false;
		}

		private string BuildPriceText(ShopOfferSO offer, bool owned)
		{
			return null;
		}

		public void OnClickBuy(string offerId)
		{
		}

		public void OnClickRestore()
		{
		}

		private ShopOfferSO FindOfferById(string offerId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCollectProductIds_003Ed__25))]
		private static IEnumerable<string> CollectProductIds(ShopCatalogSO c)
		{
			return null;
		}
	}
}
