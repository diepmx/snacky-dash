using System.Collections.Generic;

public static class CollectionLogger
{
	private static readonly string headerColor;

	private static readonly string keyColor;

	private static readonly string listItemColor;

	private static readonly string valueColor;

	public static void LogDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string header = "")
	{
	}

	public static void LogList<T>(List<T> list, string header = "")
	{
	}

	public static void LogHashSet<T>(HashSet<T> set, string header = "")
	{
	}
}
