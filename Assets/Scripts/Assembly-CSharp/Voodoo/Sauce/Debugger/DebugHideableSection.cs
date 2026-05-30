using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.Debugger
{
	public class DebugHideableSection : Widget
	{
		[SerializeField]
		private Button buttonShowHide;

		[SerializeField]
		private Image showHideImage;

		[SerializeField]
		private Sprite collapseSprite;

		[SerializeField]
		private Sprite expandSprite;

		private readonly List<GameObject> children;

		private bool isShown;

		public bool IsShown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<DebugHideableSection> OnShownStateChanged
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

		public void AddChild(GameObject child)
		{
		}

		public void UpdateDisplay(bool show)
		{
		}
	}
}
