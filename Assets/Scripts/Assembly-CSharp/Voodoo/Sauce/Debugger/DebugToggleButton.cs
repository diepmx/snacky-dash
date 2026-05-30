using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voodoo.Sauce.Internal.DebugScreen;

namespace Voodoo.Sauce.Debugger
{
	public class DebugToggleButton : Widget, IDebugRefreshable
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Sprite _toggleOn;

		[SerializeField]
		private Sprite _toggleOff;

		private Func<bool> _refreshFunction;

		public void Initialize(string title, bool value, Action<bool> onValueChanged, Func<bool> refreshFunc = null)
		{
		}

		private void SetRefreshFunction(Func<bool> refreshFunc)
		{
		}

		public void SetTitle(string title)
		{
		}

		public void SetValue(bool isOn)
		{
		}

		public void SetValue(bool? isOn)
		{
		}

		public void SetValueWithoutNotify(bool isOn)
		{
		}

		private void ChangeUI(bool isOn)
		{
		}

		public void Refresh()
		{
		}

		public void SetCallback(Action<bool> callback)
		{
		}
	}
}
