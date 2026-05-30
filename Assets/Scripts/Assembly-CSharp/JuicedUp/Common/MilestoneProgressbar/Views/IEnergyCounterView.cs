using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public interface IEnergyCounterView
	{
		RectTransform EnergyCounterRectTransform { get; }

		UniTask ShowEnergyCounter(CancellationToken token);

		UniTask HideEnergyCounter(bool withAnimation, CancellationToken token);

		void SetEnergyCounterValue(float energyValue);

		void SetEnergyImage(Sprite sprite);
	}
}
