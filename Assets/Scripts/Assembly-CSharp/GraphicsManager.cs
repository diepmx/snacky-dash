using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
	public static GraphicsManager instance;

	public List<IconsItem> iconsItems;

	public GraphicsSet graphicsSet;

	public Dictionary<PillKind, IconsItem> dict_IconsItems;

	private void Awake()
	{
	}

	public Sprite GetIconFromDictionary(PillKind pillKind, Dictionary<PillKind, IconsItem> dict, bool withOutline = true)
	{
		return null;
	}

	private void BuildDictionary()
	{
	}
}
