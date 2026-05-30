using System;
using UnityEngine;
using VContainer.Unity;

namespace Voodoo.Distribution
{
	public sealed class LocalizationDebugger : IStartable, ITickable, IDisposable
	{
		private const KeyCode LongestStringModeKey = KeyCode.O;

		private const KeyCode NextLanguageKey = KeyCode.L;

		private int _forcedIndex;

		private string[] _languageCodes;

		void IDisposable.Dispose()
		{
		}

		void IStartable.Start()
		{
		}

		void ITickable.Tick()
		{
		}

		private void CycleLanguage()
		{
		}

		private void EnableLongestStringMode()
		{
		}
	}
}
