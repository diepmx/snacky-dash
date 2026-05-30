using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;

namespace JuicedUp.Features.Settings
{
	public class LanguageSelector : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _languageNameText;

		[SerializeField]
		private GameObject _buttonBack;

		[SerializeField]
		private GameObject _buttonNext;

		[SerializeField]
		private LanguageSelectorConfiguration _configuration;

		private SettingsApplier _settingsApplier;

		private SettingsRepository _settingsRepository;

		private IReadOnlyList<LanguageSelectorConfiguration.LanguageCode> Codes => null;

		private int CurrentIndex => 0;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[Inject]
		private void Construct(SettingsApplier settingsApplier, SettingsRepository settingsRepository)
		{
		}

		public void Next()
		{
		}

		public void Back()
		{
		}

		private void Shift(int direction)
		{
		}

		private void UpdateLanguage()
		{
		}

		private void SetButtonsActive(bool active)
		{
		}
	}
}
