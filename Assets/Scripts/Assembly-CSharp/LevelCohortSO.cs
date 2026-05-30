using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCohort", menuName = "JuiceUp/Level Cohort", order = 1)]
public class LevelCohortSO : ScriptableObject
{
	[Delayed]
	public string cohortName;

	public List<LevelDataSO> levels;

	[Tooltip("When true, the cohort repeats indefinitely after all levels are completed. When false, the sequence ends after the last level.")]
	public bool isLoop;

	[Tooltip("0-based index of the first level in the loop range. Levels before this index are skipped during loops.")]
	public int loopStartIndex;
}
