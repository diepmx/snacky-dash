using System;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(fileName = "LevelCohortBindings", menuName = "JuiceUp/Level Cohort Bindings")]
	public class LevelCohortBindings : ScriptableObject
	{
		[Tooltip("Asset name of the fallback cohort under Resources/Cohorts/. Used when no valid remote cohort resolves.")]
		[SerializeField]
		private LevelCohortId _defaultCohortId;

		[NonSerialized]
		private LevelCohortSO _primaryCohort;

		public string DefaultCohortId => null;

		public LevelCohortSO PrimaryCohort
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
