using System.Threading;
using Cysharp.Threading.Tasks;
using JuicedUp.Common.MilestoneProgressbar.Data;

namespace JuicedUp.Common.MilestoneProgressbar.Controllers
{
	public interface IMilestoneProgressbarController
	{
		UniTask Initialize(MilestoneProgressbarPayload payload, CancellationToken token);

		UniTask Execute(CancellationToken token);

		void Deactivate();
	}
}
