using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Economy.Internal.Components;
using JuicedUp.Common.Economy.Internal.Pools;
using JuicedUp.Common.Economy.Public;
using JuicedUp.Common.Economy.Public.AnimationsPlayers;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Common.Economy.Public.Providers;
using UnityEngine;

namespace JuicedUp.Common.Economy.Internal.AnimationsPlayers
{
	internal class RewardFlyParticleAnimationPlayer : IRewardFlyAnimationPlayer
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CPlay_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public RewardFlyParticleAnimationPlayer _003C_003E4__this;

			public Action onSingleParticleArrived;

			public IReward reward;

			public Transform from;

			public Transform to;

			public CancellationToken token;

			private RewardFlyParticle _003Cparticle_003E5__2;

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

		private readonly IEconomySpritesProvider _spritesProvider;

		private readonly IRewardFlyParticlePool _particlePool;

		private readonly IRewardParticlesPolicy _particlesPolicy;

		public RewardFlyParticleAnimationPlayer(IEconomySpritesProvider spritesProvider, IRewardFlyParticlePool particlePool, IRewardParticlesPolicy particlesPolicy)
		{
		}

		[AsyncStateMachine(typeof(_003CPlay_003Ed__4))]
		public UniTask Play(IReward reward, Transform from, Transform to, CancellationToken token, Action onSingleParticleArrived = null)
		{
			return default(UniTask);
		}
	}
}
