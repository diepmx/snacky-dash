using System;
using JetBrains.Annotations;

namespace Voodoo.ADN.Internal
{
	public static class AdnLogger
	{
		public enum LogLevel
		{
			None = 0,
			Error = 1,
			Warning = 2,
			Debug = 3
		}

		public interface ICustomLogger
		{
			void Log(string tag, string message, LogLevel level);
		}

		private const string TAG = "[AdnSdk]";

		internal static LogLevel CurrentLogLevel { get; set; }

		[CanBeNull]
		internal static ICustomLogger CustomLogger { private get; set; }

		public static void LogError(Exception e)
		{
		}

		public static void LogError(string message)
		{
		}

		public static void LogWarning(string message)
		{
		}

		public static void LogDebug(string message)
		{
		}

		private static void Log(string message, LogLevel level)
		{
		}
	}
}
