using System.Diagnostics;

namespace JuicedUp.Features.CloudContent
{
	public static class CloudLog
	{
		private const string Tag = "[CloudContent]";

		private const string InfoColor = "#00BFFF";

		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		public static void Info(string message)
		{
		}

		public static void Warning(string message)
		{
		}

		public static void Error(string message)
		{
		}
	}
}
