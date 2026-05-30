using System.Threading;
using UnityEngine;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class BattlePassUIPanelBase : MonoBehaviour
	{
		public bool IsPanelActive => false;

		public CancellationTokenSource CancellationTokenSource { get; set; }

		public void CancelTask()
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}
	}
}
