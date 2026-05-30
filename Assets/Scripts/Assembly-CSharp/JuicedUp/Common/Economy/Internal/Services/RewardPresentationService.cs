using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.AnimationsPlayers;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using JuicedUp.Common.Economy.Public.Services;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.Services
{
	internal class RewardPresentationService : IRewardPresentationService
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass5_0
		{
			public RewardPresentationContext context;

			public int arrivedCount;

			public int baseDelta;

			public int remainder;

			public int remaining;

			public IReward reward;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlay_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPresentationContext context;

			public RewardPresentationService _003C_003E4__this;

			public CancellationToken cancellationToken;

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
		private struct _003CPlaySingle_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardPresentationContext context;

			public IReward reward;

			public RewardPresentationService _003C_003E4__this;

			public Transform from;

			public Transform to;

			public CancellationToken cancellationToken;

			private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

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

		private readonly IActiveRewardHudViewProvider _hudViewProvider;

		private readonly IRewardFlyAnimationPlayer _animationPlayer;

		private readonly IRewardParticlesPolicy _particlesPolicy;

		public RewardPresentationService(IActiveRewardHudViewProvider hudViewProvider, IRewardFlyAnimationPlayer animationPlayer, IRewardParticlesPolicy particlesPolicy)
		{
		}

		[AsyncStateMachine(typeof(_003CPlay_003Ed__4))]
		public UniTask Play(RewardPresentationContext context, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CPlaySingle_003Ed__5))]
		private UniTask PlaySingle(IReward reward, Transform from, Transform to, RewardPresentationContext context, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		private Transform ResolveTarget(RewardVisualSource rewardVisualSource)
		{
			return null;
		}
	}
}
