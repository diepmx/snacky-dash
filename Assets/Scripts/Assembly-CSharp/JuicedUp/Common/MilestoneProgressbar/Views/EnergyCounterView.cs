using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public class EnergyCounterView : MonoBehaviour, IEnergyCounterView
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHideEnergyCounter_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public bool withAnimation;

			public EnergyCounterView _003C_003E4__this;

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
		private struct _003CShowEnergyCounter_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public EnergyCounterView _003C_003E4__this;

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
		private TextMeshProUGUI _energyCounterText;

		[SerializeField]
		private RectTransform _energyCounter;

		[SerializeField]
		private Image _energyCounterImage;

		[Space]
		[SerializeField]
		private Animation _energyCounterAnimation;

		[SerializeField]
		private AnimationClip _showAnimationClip;

		[SerializeField]
		private AnimationClip _hideAnimationClip;

		public RectTransform EnergyCounterRectTransform => null;

		[AsyncStateMachine(typeof(_003CShowEnergyCounter_003Ed__8))]
		public UniTask ShowEnergyCounter(CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CHideEnergyCounter_003Ed__9))]
		public UniTask HideEnergyCounter(bool withAnimation, CancellationToken token)
		{
			return default(UniTask);
		}

		public void SetEnergyCounterValue(float energyValue)
		{
		}

		public void SetEnergyImage(Sprite sprite)
		{
		}
	}
}
