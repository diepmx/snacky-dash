using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Economy.Public.Views;
using JuicedUp.Common.MilestoneProgressbar.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.WeeklyMissions.Internal
{
	internal class MilestoneProgressBarView : MonoBehaviour, IMilestoneProgressBarView, IProgressBarView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdateSlider_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public bool withAnimation;

			public MilestoneProgressBarView _003C_003E4__this;

			public float endValue;

			public float duration;

			public Ease ease;

			public CancellationToken token;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private RectTransform _milestoneMarkersContainer;

		[SerializeField]
		private Image _energyImage;

		[SerializeField]
		private TextMeshProUGUI _finishEnergyText;

		[SerializeField]
		private TextMeshProUGUI _currentEnergyText;

		[SerializeField]
		private TextMeshProUGUI _completedText;

		[SerializeField]
		private GrandMilestoneView _grandMilestone;

		[SerializeField]
		private RewardHudView _energyHudView;

		private Tween _sliderUpdateTween;

		public RectTransform MilestoneMarkersContainer => null;

		public GrandMilestoneView GrandMilestone => null;

		public IRewardHudView EnergyHudView => null;

		[AsyncStateMachine(typeof(_003CUpdateSlider_003Ed__15))]
		public UniTask UpdateSlider(float endValue, bool withAnimation, float duration = 1f, CancellationToken token = default(CancellationToken), Ease ease = Ease.Linear)
		{
			return default(UniTask);
		}

		public void SetEnergyIcon(Sprite energyIcon)
		{
		}

		public void SetFinishEnergyValue(string energyValue)
		{
		}

		public void SetCurrentEnergyValue(string energyValue)
		{
		}

		public void SetCompletedState(bool isVisible)
		{
		}

		public void SetInProgressState(bool isVisible)
		{
		}
	}
}
