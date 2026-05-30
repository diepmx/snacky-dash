using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Voodoo.Live.Debugger
{
	public class VoodooLiveDebugUI
	{
		public Label labelPrefab;

		public DebuggerKeyValuePair keyValuePair;

		public DebuggerKeyInputPair keyInputPair;

		public DebuggerKeyButtonPair keyButtonPair;

		public DebuggerLabelAndDivider labelAndDivider;

		public Transform rootObject;

		public Label label;

		public List<GameObject> pairs;

		public virtual void Init()
		{
		}

		public void Clear()
		{
		}

		public void CreateValuePair(string key, string value)
		{
		}

		public void CreateInputPair(string key, string value, UnityAction<string> onEdit)
		{
		}

		public void CreateButtonPair(string key, string buttonTitle, UnityAction onClick)
		{
		}

		public void CreateLabelAndDivider(string key)
		{
		}
	}
}
