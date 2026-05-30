using System;
using Audiomob.Internal;
using UnityEngine;

namespace Audiomob.Unmanaged
{
	public class AudiomobPluginInitialization
	{
		private static bool ManualInitializationEnabled;

		public static IMediationAdapterSdk MediationAdapterSdk { private get; set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RegisterInitializationHook()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializePluginAutomatically()
		{
		}

		public static void InitializePlugin(Action<bool> callback = null)
		{
		}

		private static void DoInitialization(Action<bool> callback = null)
		{
		}

		private static void InvokeInitCallback(Action<bool> callback, bool initSuccess)
		{
		}
	}
}
