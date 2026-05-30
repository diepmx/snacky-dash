using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
	[SerializeField]
	private List<TKey> keys;

	[SerializeField]
	private List<TValue> values;

	public Dictionary<TKey, TValue> ToDictionary()
	{
		return null;
	}

	public void FromDictionary(Dictionary<TKey, TValue> dictionary)
	{
	}
}
