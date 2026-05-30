using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Voodoo.Sauce.Debugger
{
	[RequireComponent(typeof(Canvas))]
	public class DebuggerCanvas : MonoBehaviour
	{
		[SerializeField]
		private DebuggerCanvasData _data;

		[SerializeField]
		private HomeDebugScreen _homePrefab;

		[SerializeField]
		private DebuggerHeader _header;

		[SerializeField]
		private Transform _bodyRoot;

		[SerializeField]
		private Transform _hiddenRoot;

		[SerializeField]
		private DebuggerPopupScreen _popupScreen;

		[SerializeField]
		private CustomDebuggerScreen _customDebuggerScreen;

		private Canvas _canvas;

		private Stack<Screen> _screenQueue;

		private bool _wasOpen;

		public bool IsOpened => false;

		public bool IsHome => false;

		public static event Action OnOpened
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

		public static event Action OnClosed
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

		private void Awake()
		{
		}

		public void Open()
		{
		}

		public void Push(Screen screen)
		{
		}

		public Screen Pop()
		{
			return null;
		}

		public void Toggle(Screen screen)
		{
		}

		private void SetScreenVisibility(Screen screen, bool visible)
		{
		}

		public void UpdateHeader(Screen screen)
		{
		}

		public void Close()
		{
		}

		public void ShowPopup(DebuggerPopupConfig config)
		{
		}
	}
}
