using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace JuicedUp.Common.MilestoneProgressbar.Views
{
	public interface IProgressBarView
	{
		UniTask UpdateSlider(float endValue, bool withAnimation, float duration = 1f, CancellationToken token = default(CancellationToken), Ease ease = Ease.Linear);
	}
}
