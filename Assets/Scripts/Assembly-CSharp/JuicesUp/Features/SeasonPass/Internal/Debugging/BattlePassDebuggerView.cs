using UnityEngine;
using VContainer;

namespace JuicesUp.Features.SeasonPass.Internal.Debugging
{
	internal class BattlePassDebuggerView : MonoBehaviour
	{
		private BattlePassDebugger _debugger;

		[Inject]
		private void Construct(BattlePassDebugger debugger)
		{
		}

		private void TestPurchaseSuccessDone()
		{
		}

		private void DebugSetServerTime10SecBeforeEnd()
		{
		}

		private void DebugSetServerTimeToEndDate()
		{
		}
	}
}
