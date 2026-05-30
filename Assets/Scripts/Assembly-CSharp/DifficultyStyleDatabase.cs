using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Difficulty Style Database")]
public class DifficultyStyleDatabase : ScriptableObject
{
	[Serializable]
	public struct Entry
	{
		public LevelDifficulty difficulty;

		public Sprite nodeSprite;

		public Color pillBackgroundColor;

		public string labelOverride;
	}

	[SerializeField]
	private Entry[] entries;

	private Dictionary<LevelDifficulty, Entry> _map;

	public Entry Get(LevelDifficulty difficulty)
	{
		return default(Entry);
	}

	public static string DefaultLabel(LevelDifficulty d)
	{
		return null;
	}
}
