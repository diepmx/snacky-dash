using System;
using UnityEngine;

namespace JuicedUp.Features.Settings
{
	public class SettingsToggle : MonoBehaviour
	{
		[SerializeField]
		private SettingType _settingType;

		[SerializeField]
		private GameObject _onState;

		[SerializeField]
		private GameObject _offState;

		private bool _isOn;

		private Action<SettingType, bool> _onToggled;

		public SettingType SettingType => default(SettingType);

		public void Initialize(bool isOn, Action<SettingType, bool> onToggled)
		{
		}

		public void Toggle()
		{
		}

		public void SetState(bool isOn)
		{
		}

		private void UpdateView()
		{
		}
	}
}
