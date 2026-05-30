using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class TransactionSection : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TransactionSubHeader _subHeader;

		[SerializeField]
		private TextMeshProUGUI _cacheTXT;

		[SerializeField]
		private Transform _cacheLine;

		[SerializeField]
		private Button _copyBtn;

		[SerializeField]
		private Transform _contentTransform;

		public void Init()
		{
		}

		private void CopyToClipboard()
		{
		}
	}
}
