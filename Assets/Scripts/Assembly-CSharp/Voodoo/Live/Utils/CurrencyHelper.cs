using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Voodoo.Live.Utils
{
	public static class CurrencyHelper
	{
		private const int DefaultCurrencyScalePercent = 130;

		private static readonly Dictionary<string, int> CurrencyScaleOverrides;

		private static readonly Regex CurrencySymbolRegex;

		public static string FormatPriceForUniformSize(string priceText)
		{
			return null;
		}

		public static string GetCurrencyCharacter(string isoCurrencyCode)
		{
			return null;
		}
	}
}
