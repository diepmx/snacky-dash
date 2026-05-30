using UnityEngine;

namespace JuicedUp.Features.LoseTutorial.Config
{
	[CreateAssetMenu(fileName = "LoseTutorialConfigSO", menuName = "JuicedUp/LoseTutorial/Config", order = 0)]
	public sealed class LoseTutorialConfigSO : ScriptableObject
	{
		[SerializeField]
		[Min(1f)]
		private int _targetLevelIndex;

		public int TargetLevelIndex => 0;
	}
}
