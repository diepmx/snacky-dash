using System;
using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Settings
{
	[CreateAssetMenu(menuName = "JuicedUp/Settings/LanguageSelectorConfigs")]
	public class LanguageSelectorConfiguration : ScriptableObject
	{
		[Serializable]
		public class LanguageCode
		{
			[SerializeField]
			private string _code;

			[SerializeField]
			private string _name;

			public string Code => null;

			public string Name => null;
		}

		[SerializeField]
		private List<LanguageCode> _codes;

		public IReadOnlyList<LanguageCode> Codes => null;
	}
}
