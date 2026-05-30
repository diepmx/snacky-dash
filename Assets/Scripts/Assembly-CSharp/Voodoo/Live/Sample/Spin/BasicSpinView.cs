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
	public class BasicSpinView : FeaturePopup
	{
		[CompilerGenerated]
		private sealed class _003CSpinMotion_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BasicSpinView _003C_003E4__this;

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
			public _003CSpinMotion_003Ed__26(int _003C_003E1__state)
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

		private const string TAG = "PAY_FIRST_SPIN_VIEW";

		public Button closeBtn;

		public Transform wheel;

		public List<Color> sliceColors;

		public WheelPie piePrefab;

		public TextMeshProUGUI rewardDisplay;

		public float spinDuration;

		public AnimationCurve decelerationCurve;

		public OfferPurchaseBtnUI purchaseBtn;

		public TextMeshProUGUI purchaseBtnText;

		public GameObject rewardWindowGO;

		public TextMeshProUGUI rewardTxt;

		public Image rewardIcon;

		public Button rewardCloseBtn;

		public GameObject loadingScreen;

		private float _anglePerReward;

		private bool _isSpinning;

		private IReadOnlyList<Reward> _rewards;

		private BasicSpin _spin;

		public override void Show()
		{
		}

		private void GenerateWheel(BasicSpin spin)
		{
		}

		public int GetRewardIndex()
		{
			return 0;
		}

		public override void Purchase()
		{
		}

		public override void OnStatusChanged(string status, IFeature feature)
		{
		}

		private void RollUI()
		{
		}

		private float CalculateFinalWheelAngle()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CSpinMotion_003Ed__26))]
		private IEnumerator SpinMotion(float totalRotation)
		{
			return null;
		}

		private void ShowReward()
		{
		}

		public override void Hide()
		{
		}
	}
}
