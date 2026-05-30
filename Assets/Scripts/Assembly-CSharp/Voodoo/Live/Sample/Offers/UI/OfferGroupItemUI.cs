using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Sample.Offers.UI
{
	public class OfferGroupItemUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateOtherObjects_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OfferGroupItemUI _003C_003E4__this;

			private GridLayoutGroup _003CgridLayoutGroup_003E5__2;

			private Transform _003Cparent_003E5__3;

			private Vector3[] _003CoriginalPositions_003E5__4;

			private List<Vector3> _003CtargetPositions_003E5__5;

			private float _003CelapsedTime_003E5__6;

			object IEnumerator<object>.Current
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
			public _003CAnimateOtherObjects_003Ed__18(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CScaleDownAndHide_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OfferGroupItemUI _003C_003E4__this;

			private Vector3 _003CoriginalScale_003E5__2;

			private float _003CelapsedTime_003E5__3;

			object IEnumerator<object>.Current
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
			public _003CScaleDownAndHide_003Ed__15(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CScaleDownAndMoveToBottom_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OfferGroupItemUI _003C_003E4__this;

			private Vector3 _003CoriginalScale_003E5__2;

			private float _003CelapsedTime_003E5__3;

			object IEnumerator<object>.Current
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
			public _003CScaleDownAndMoveToBottom_003Ed__17(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Animation")]
		[SerializeField]
		private AnimationCurve _scaleCurve;

		[SerializeField]
		private AnimationCurve _positionLerpCurve;

		[SerializeField]
		private float _animationDuration;

		[Header("Prefabs")]
		[SerializeField]
		private RewardItemUI _rewardItemPrefab;

		[SerializeField]
		private OfferPurchaseBtnUI _purchaseBtnPrefab;

		[SerializeField]
		private Transform _rewardsContainer;

		[SerializeField]
		private GameObject _lockedIcon;

		private Product _product;

		private FeaturePopup _popup;

		public bool isLast;

		public Product Product => null;

		public void SetUpNPOOfferItem(Product product, Action purchase, FeaturePopup popup, bool isLast)
		{
		}

		public void Unlock(bool unlock)
		{
		}

		public void Hide()
		{
		}

		[IteratorStateMachine(typeof(_003CScaleDownAndHide_003Ed__15))]
		private IEnumerator ScaleDownAndHide()
		{
			return null;
		}

		public void MoveToBottom()
		{
		}

		[IteratorStateMachine(typeof(_003CScaleDownAndMoveToBottom_003Ed__17))]
		private IEnumerator ScaleDownAndMoveToBottom()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateOtherObjects_003Ed__18))]
		private IEnumerator AnimateOtherObjects()
		{
			return null;
		}
	}
}
