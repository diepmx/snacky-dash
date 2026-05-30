using TMPro;
using UnityEngine.Scripting;
using Voodoo.Sauce.Debugger;

namespace JuicedUp.Features.LocalizationDebug.SymbolCoverage
{
	[Preserve]
	public sealed class SymbolCoverageDebugger : CustomDebugger
	{
		private const string FallbackFontName = "Voodoo_Casual-Bold SDF";

		private const string PrimaryFontName = "LuckiestGuy-Regular SDF";

		private const string SecondaryFallbackFontName = "NotoSans-Regular SDF";

		private const float SymbolFontSize = 56f;

		public override bool ReSetupScreenOnShown => false;

		private static TMP_FontAsset FindFontByName(string fontName)
		{
			return null;
		}

		private static void EnsureFallback(TMP_FontAsset primary, TMP_FontAsset fallback)
		{
		}

		private static void AddSymbolRow(DebugHideableSection foldout, string text, TMP_FontAsset font)
		{
		}

		public override string GetTitle()
		{
			return null;
		}

		public override int GetOrderIndex()
		{
			return 0;
		}

		public override void SetupScreen(Screen screen)
		{
		}
	}
}
