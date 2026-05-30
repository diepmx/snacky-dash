using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JuicesUp.Features.SeasonPass.Internal.Core;
using KiraganGames.Ui;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassMainView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CScrollToCurrentMilestoneNextFrame_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattlePassMainView _003C_003E4__this;

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
			public _003CScrollToCurrentMilestoneNextFrame_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CShowPanel_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattlePassMainView _003C_003E4__this;

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
			public _003CShowPanel_003Ed__30(int _003C_003E1__state)
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

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private CountdownTimerText _countdownTimerText;

		[SerializeField]
		private BattlePassPurchaseButtonView _battlePassPurchaseButton;

		[Header("Feedbacks")]
		[SerializeField]
		private GameObject _rootObject;

		[SerializeField]
		private MMF_Player _openFeedback;

		[SerializeField]
		private MMF_Player _closeFeedback;

		[Header("Milestones")]
		[SerializeField]
		private Transform _milestoneContainer;

		[SerializeField]
		private BattlePassMilestoneView _firstMilestoneView;

		[SerializeField]
		private BattlePassMilestoneView _milestoneViewTemplate;

		[SerializeField]
		private BattlePassMilestoneScrollController _milestoneScrollController;

		[Header("Tutorial")]
		[SerializeField]
		private Button _tutorialButton;

		[FormerlySerializedAs("_battlePassInfoUI")]
		[SerializeField]
		private BattlePassInfoView _battlePassInfoView;

		[Header("Hints")]
		[SerializeField]
		private HintController _hintController;

		[Header("FTUE")]
		[SerializeField]
		private float _ftueScrollSpeed;

		[SerializeField]
		private float _ftueScrollEndDelay;

		private MainViewArgs _mainArgs;

		private readonly List<BattlePassMilestoneView> _milestoneViews;

		private bool _localHasSeenTutorials;

		private IBattlePassManager _battlePassManager;

		private IBattlePassAppBridge _appBridge;

		private Action _onFtueCompletedAndMainUiClosed;

		public void Initialise(IBattlePassManager battlePassManager, IBattlePassAppBridge appBridge)
		{
		}

		public void UpdateView(MainViewArgs payload)
		{
		}

		private void OnPurchaseButtonClicked()
		{
		}

		private int GetCurrentMilestoneIndex(MainViewArgs mainArgs)
		{
			return 0;
		}

		private void InstantiateMilestones(List<MilestoneViewArgs> milestones, MainViewArgs mainArgs)
		{
		}

		private void OnRewardClicked()
		{
		}

		public void Show(Action onFtueCompletedAndMainUiClosed = null)
		{
		}

		private void TryToStartFTUE()
		{
		}

		[IteratorStateMachine(typeof(_003CShowPanel_003Ed__30))]
		private IEnumerator ShowPanel()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScrollToCurrentMilestoneNextFrame_003Ed__31))]
		private IEnumerator ScrollToCurrentMilestoneNextFrame()
		{
			return null;
		}

		private void ScrollToMilestone(int index)
		{
		}

		private void ScrollFromBottomToTop(float normalizedSpeed, float endCallbackDelay, Action onComplete)
		{
		}

		internal void Hide()
		{
		}

		private void UpdateTitle(string seasonTitle)
		{
		}

		private void UpdateTimer()
		{
		}
	}
}
