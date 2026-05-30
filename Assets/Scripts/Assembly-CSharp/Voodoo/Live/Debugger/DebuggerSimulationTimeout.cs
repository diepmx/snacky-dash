using TMPro;
using UnityEngine;

namespace Voodoo.Live.Debugger
{
	public class DebuggerSimulationTimeout : MonoBehaviour
	{
		[Header("References")]
		public TMP_InputField timeoutInputField;

		private ConfigResponse _configResponse;

		public static int Timeout { get; private set; }

		private void Start()
		{
		}

		private void OnTimeoutValueChanged(string value)
		{
		}
	}
}
