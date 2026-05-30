using System.Collections.Generic;
using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public interface ILdfTutorialCondition
	{
		IngredientType Type { get; }

		bool IsAvailable(HashSet<IngredientType> levelAdmissionTypes);
	}
}
