using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LayerLab.GUIScripts
{
	public class PanelControl : MonoBehaviour
	{
		private int _page;

		private bool _isReady;

		private TextMeshProUGUI _textTitle;

		[SerializeField]
		private List<GameObject> defaultPanels;

		[SerializeField]
		private List<GameObject> otherPanels;

		[SerializeField]
		private Transform panelTransformDefault;

		[SerializeField]
		private Transform panelTransformOther;

		[SerializeField]
		private Button buttonPrev;

		[SerializeField]
		private Button buttonNext;

		private bool IsOtherMode { get; set; }

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void Click_Prev()
		{
		}

		private void Click_Next()
		{
		}

		private void SetArrowActive()
		{
		}

		private void CheckControl()
		{
		}

		public void Click_Mode()
		{
		}

		private void SetMode()
		{
		}
	}
}
