using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class DebuggerKeyButtonPair : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TextMeshProUGUI _keyText;

		[SerializeField]
		private TextMeshProUGUI _buttonTitle;

		[SerializeField]
		private Button _button;

		public void Init(string key, string buttonTitle, UnityAction onClick)
		{
		}
	}
}
