using System.Collections.Generic;
using UnityEngine;

public class CoverMap : MonoBehaviour
{
	public static CoverMap instance;

	private readonly Dictionary<Vector3Int, GameObject> coverDictionary;

	private void Awake()
	{
	}

	public void RegisterCoverObject(Vector3Int cellPos, GameObject obj)
	{
	}

	public GameObject GetCoverAt(Vector3Int cellPos)
	{
		return null;
	}

	public void UnregisterCoverObject(Vector3Int cellPos)
	{
	}

	public void PrintAllCovers()
	{
	}
}
