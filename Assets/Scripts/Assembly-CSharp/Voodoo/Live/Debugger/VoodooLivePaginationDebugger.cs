using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class VoodooLivePaginationDebugger : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Button _nextPageBtn;

		[SerializeField]
		private Button _previousPageBtn;

		[SerializeField]
		private TextMeshProUGUI _counter;

		public int CurrentPageIndex;

		private OffersSubHeader _subheader;

		public void Init(OffersSubHeader subheader)
		{
		}

		private void UpdateCounter()
		{
		}

		public void NextPage()
		{
		}

		public void PreviousPage()
		{
		}
	}
}
