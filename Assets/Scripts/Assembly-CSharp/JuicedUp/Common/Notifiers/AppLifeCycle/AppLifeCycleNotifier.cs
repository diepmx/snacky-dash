using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace JuicedUp.Common.Notifiers.AppLifeCycle
{
	public class AppLifeCycleNotifier : MonoBehaviour, IAppLifeCycleNotifier
	{
		public event Action<bool> ApplicationFocusChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<bool> ApplicationPauseChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ApplicationQuited
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action LateUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void LateUpdate()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
