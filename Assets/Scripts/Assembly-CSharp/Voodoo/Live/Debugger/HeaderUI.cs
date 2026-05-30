using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Live.Debugger
{
	public class HeaderUI : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private Transform _arrowTransform;

		[SerializeField]
		private GameObject _sectionContent;

		private void Awake()
		{
		}

		private void ToggleHeader(bool value)
		{
		}
	}
}
