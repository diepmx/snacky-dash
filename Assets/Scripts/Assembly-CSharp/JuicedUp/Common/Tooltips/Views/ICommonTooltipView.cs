using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.Tooltips.Data;
using UnityEngine;

namespace JuicedUp.Common.Tooltips.Views
{
	public interface ICommonTooltipView
	{
		Transform GetFreeRewardsContainer { get; }

		GameObject GameObject { get; }

		void ActivateTriangle(TooltipDirection direction, Vector2 pivotOffset);

		void SetParent(Transform parent);

		void SetTitleText(string text);

		UniTask WaitForScreenClickAsync(CancellationToken token);

		UniTask Show(CancellationToken token);

		UniTask Hide(bool withAnimation, CancellationToken token);
	}
}
