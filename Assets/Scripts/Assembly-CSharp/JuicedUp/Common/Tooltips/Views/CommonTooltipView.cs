using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Internal.Views;
using JuicedUp.Common.Tooltips.Data;
using TMPro;
using UnityEngine;

namespace JuicedUp.Common.Tooltips.Views
{
	public class CommonTooltipView : MonoBehaviour, ICommonTooltipView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHide_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public bool withAnimation;

			public CommonTooltipView _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShow_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CommonTooltipView _003C_003E4__this;

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
		private bool _isActiveOnStart;

		[Space]
		[SerializeField]
		private GameObject _leftTriangle;

		[SerializeField]
		private GameObject _rightTriangle;

		[SerializeField]
		private GameObject _topTriangle;

		[SerializeField]
		private GameObject _bottomTriangle;

		[Space]
		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private RewardsContainer[] _rewardContainers;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _showAnimationClip;

		[SerializeField]
		private AnimationClip _hideAnimationClip;

		private RectTransform _tooltipRectTransform;

		public Transform GetFreeRewardsContainer => null;

		public GameObject GameObject => null;

		private void Awake()
		{
		}

		public void ActivateTriangle(TooltipDirection direction, Vector2 pivotOffset)
		{
		}

		public void SetParent(Transform parent)
		{
		}

		public void SetTitleText(string text)
		{
		}

		[AsyncStateMachine(typeof(_003CShow_003Ed__19))]
		public UniTask Show(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHide_003Ed__20))]
		public UniTask Hide(bool withAnimation, CancellationToken token)
		{
			return default(UniTask);
		}

		public UniTask WaitForScreenClickAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private Transform SelectFreeRewardsContainer()
		{
			return null;
		}
	}
}
