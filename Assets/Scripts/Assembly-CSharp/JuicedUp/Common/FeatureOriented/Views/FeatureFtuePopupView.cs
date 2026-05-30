using System;
using UnityEngine;

namespace JuicedUp.Common.FeatureOriented.Views
{
	public class FeatureFtuePopupView : MonoBehaviour
	{
		[HideInInspector]
		public bool open;

		private Action _onClose;

		private void Awake()
		{
		}

		public void Show(Action onClose = null)
		{
		}

		public void Close()
		{
		}

		public void Hide()
		{
		}
	}
}
