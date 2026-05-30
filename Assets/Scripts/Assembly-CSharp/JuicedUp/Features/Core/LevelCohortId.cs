using UnityEngine;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(fileName = "LevelCohortBindings", menuName = "JuiceUp/Level Cohort Id")]
	public class LevelCohortId : ScriptableObject
	{
		[ReadOnly]
		private string CohortDisplay => null;

		public string CohortId => null;
	}
}
