using System;
using System.Collections.Generic;
using UnityEngine;

namespace Voodoo.ADN.Internal
{
	public class AdnEventExecutor : MonoBehaviour
	{
		private const string ExecutorName = "AdnEventExecutor";

		private static AdnEventExecutor _instance;

		private static readonly List<Action> _eventQueue;

		private static bool _isQueueEmpty;

		public static void InitializeIfNeeded()
		{
		}

		public static void ExecuteOnMainThread(Action action)
		{
		}

		private static void Enqueue(Action action)
		{
		}

		private static void SafeInvoke(Action action)
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}
	}
}
