using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Common.Economy.Public.AnimationsPlayers
{
	public interface IRewardFlyAnimationPlayer
	{
		UniTask Play(IReward reward, Transform from, Transform to, CancellationToken token, Action onSingleParticleArrived = null);
	}
}
