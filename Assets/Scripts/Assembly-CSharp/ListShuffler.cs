using System;
using System.Collections.Generic;

public static class ListShuffler
{
	private static readonly Random rng;

	public static void Shuffle<T>(this IList<T> list)
	{
	}

	public static void Shuffle<T>(this IList<T> list, Random random)
	{
	}
}
