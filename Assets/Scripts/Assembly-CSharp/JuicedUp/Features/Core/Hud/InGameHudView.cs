using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Core.Hud
{
	public class InGameHudView : MonoBehaviour
	{
		[SerializeField]
		private Button _settingsButton;

		[SerializeField]
		private TextMeshProUGUI _levelText;

		[SerializeField]
		private LevelCompletionBarUI _levelCompletionBarUI;

		public Button SettingsButton => null;

		public TextMeshProUGUI LevelText => null;

		public LevelCompletionBarUI LevelCompletionBarUI => null;

		public void SetVisible(bool visible)
		{
		}
	}
}
