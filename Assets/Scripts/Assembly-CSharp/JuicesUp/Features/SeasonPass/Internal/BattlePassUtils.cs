using System;
using System.Collections.Generic;
using UnityEngine;
using Voodoo.Live;

namespace JuicesUp.Features.SeasonPass.Internal
{
	internal static class BattlePassUtils
	{
		public static IReadOnlyList<string> GetTags(IConditionnal conditionnal)
		{
			return null;
		}

		public static bool HasTag(IConditionnal conditionnal, string tag)
		{
			return false;
		}

		public static string GetItemName(ItemQuantity itemQuantity)
		{
			return null;
		}

		public static void Log(string message)
		{
		}

		public static void LogWarning(string message)
		{
		}

		public static void LogError(string message)
		{
		}

		public static void LogException(this UnityEngine.Object myObj, Exception exception)
		{
		}

		public static void LogException(this Exception exception)
		{
		}
	}
}
