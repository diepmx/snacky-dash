using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Live.Offers;
using Voodoo.Live.Sample.Offers;
using Voodoo.Live.Sample.Offers.UI;

namespace Voodoo.Live.Sample.Spin
{
	public class SpinWithRerollView : FeaturePopup
	{
		[CompilerGenerated]
		private sealed class _003CRewardPlayer_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpinWithRerollView _003C_003E4__this;

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
			public _003CRewardPlayer_003Ed__36(int _003C_003E1__state)
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
		private sealed class _003CSpinMotion_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpinWithRerollView _003C_003E4__this;

			public float totalRotation;

			private float _003CelapsedTime_003E5__2;

			private float _003CcurrentAngle_003E5__3;

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
			public _003CSpinMotion_003Ed__35(int _003C_003E1__state)
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

		private const string TAG = "SPIN_FIRST_SPIN_VIEW";

		public Button closeBtn;

		public Transform wheel;

		public List<Color> sliceColors;

		public WheelPie piePrefab;

		public TextMeshProUGUI rewardDisplay;

		public float spinDuration;

		public AnimationCurve decelerationCurve;

		public OfferPurchaseBtnUI purchaseBtn;

		public OfferPurchaseBtnUI rerollBtn;

		public TextMeshProUGUI purchaseBtnText;

		public TextMeshProUGUI rerollBtnTxt;

		public GameObject bottomGO;

		public GameObject rerollLimitGO;

		public TextMeshProUGUI rerollLimitText;

		public GameObject rewardWindowGO;

		public TextMeshProUGUI rewardTxt;

		public Image rewardIcon;

		public Button rewardCloseBtn;

		public Button spinBtn;

		public GameObject loadingScreen;

		private float _anglePerReward;

		private bool _isSpinning;

		private IReadOnlyList<Reward> _rewards;

		private SpinWithReroll _spin;

		public override void Show()
		{
		}

		private void GenerateWheel(SpinWithReroll spin)
		{
		}

		private void SpinWheel()
		{
		}

		private void BuyReroll()
		{
		}

		public override void Purchase()
		{
		}

		public override void OnStatusChanged(string status, IFeature feature)
		{
		}

		private void ShowReward()
		{
		}

		private void RollUI()
		{
		}

		private float CalculateFinalWheelAngle()
		{
			return 0f;
		}

		private int GetRewardIndex()
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CSpinMotion_003Ed__35))]
		private IEnumerator SpinMotion(float totalRotation)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRewardPlayer_003Ed__36))]
		private IEnumerator RewardPlayer()
		{
			return null;
		}

		private void RerollLimitReached()
		{
		}

		public override void Hide()
		{
		}
	}
}
