using System.Threading;
using UnityEngine;

namespace JuicedUp.Core.Bootstrap
{
	public static class SessionCancellationToken
	{
		private static CancellationTokenSource _cts;

		public static CancellationToken Token => default(CancellationToken);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
		}

		private static void OnQuit()
		{
		}
	}
}
