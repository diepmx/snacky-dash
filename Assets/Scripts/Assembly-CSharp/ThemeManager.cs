using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
	public static ThemeManager instance;

	public int changeThemeEvery;

	public bool useSeparateMaterials;

	public List<Material> materialsTheme;

	private void Awake()
	{
	}

	public Material GetMaterialForLevel(int level)
	{
		return null;
	}
}
