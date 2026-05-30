using System.Collections.Generic;
using JuicedUp.Features.Core.Ingredients;
using UnityEngine;

public class LevelMeta : MonoBehaviour
{
	[Header("Core")]
	public LevelDifficulty difficulty;

	public int difficultyScore;

	public LevelDesigner design;

	public LevelSize levelSize;

	public List<IngredientType> allIngredients;

	public List<LevelCategory> levelCategories;

	public float secondsToComplete;
}
