using System.Collections.Generic;
using JuicedUp.Features.Core.Ingredients;

namespace JuicedUp.Features.Core.LdfTutorial
{
	public abstract class BaseLdfTutorialCondition : ILdfTutorialCondition
	{
		private readonly ILdfTutorialRepository _repository;

		public abstract IngredientType Type { get; }

		protected BaseLdfTutorialCondition(ILdfTutorialRepository repository)
		{
		}

		public bool IsAvailable(HashSet<IngredientType> levelAdmissionTypes)
		{
			return false;
		}
	}
}
