using System.Threading;
using Cysharp.Threading.Tasks;

namespace JuicedUp.Common.Tooltips.Controllers
{
	public interface ITooltipController
	{
		UniTask Initialize(CancellationToken token);

		UniTask Execute(CancellationToken token);

		void Deactivate();
	}
}
