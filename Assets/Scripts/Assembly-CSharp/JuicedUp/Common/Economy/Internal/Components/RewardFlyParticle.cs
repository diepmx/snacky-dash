using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AssetKits.ParticleImage;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Components
{
	internal class RewardFlyParticle : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlay_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardFlyParticle _003C_003E4__this;

			public Transform fromPosition;

			public Sprite sprite;

			public Transform toPosition;

			public int particlesAmount;

			public bool isTextureSheet;

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
		private ParticleImage _particleImage;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[Space]
		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private AnimationClip _simpleDispAnimation;

		[SerializeField]
		private AnimationClip _upDispAnimation;

		public event Action SingleParticleArrived
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

		private void OnDestroy()
		{
		}

		[AsyncStateMachine(typeof(_003CPlay_003Ed__10))]
		public UniTask Play(Sprite sprite, Transform fromPosition, Transform toPosition, int particlesAmount, bool isTextureSheet, CancellationToken token)
		{
			return default(UniTask);
		}

		public void ActivateSimpleDisappearAmountAnimation(string formatedRewardAmount)
		{
		}

		public void ActivateUpDisappearAmountAnimation(string formatedRewardAmount)
		{
		}

		private void OnSingleParticleArrived()
		{
		}
	}
}
