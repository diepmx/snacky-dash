using UnityEngine;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(fileName = "GuidanceConfig", menuName = "JuicedUp/Guidance Config")]
	public sealed class GuidanceConfig : ScriptableObject
	{
		[Header("Lifetime")]
		[Tooltip("Last level index (0-based) where guidance is active. Level 10 = index 9")]
		[field: SerializeField]
		public int MaxLevelActive { get; private set; }

		[Header("Timing")]
		[Tooltip("Seconds of idle at a junction before arrows appear")]
		[field: SerializeField]
		public float IdleDelaySeconds { get; private set; }

		[Tooltip("Optional per-level delay overrides. Index = level index. If entry exists and > 0, overrides IdleDelaySeconds")]
		[field: SerializeField]
		public float[] PerLevelIdleOverrides { get; private set; }

		[Header("Arrows")]
		[Tooltip("Max number of arrows to display")]
		[field: SerializeField]
		public int MaxArrowCount { get; private set; }

		[Header("Animation")]
		[Tooltip("Duration for a single arrow to fade from 0 to full alpha")]
		[field: SerializeField]
		public float FadeInDuration { get; private set; }

		[Tooltip("Delay between each arrow starting its fade-in (cascading effect)")]
		[field: SerializeField]
		public float CascadeDelay { get; private set; }

		[Tooltip("Duration arrows stay fully visible after all have faded in")]
		[field: SerializeField]
		public float HoldDuration { get; private set; }

		[Tooltip("Duration for all arrows to fade out together")]
		[field: SerializeField]
		public float FadeOutDuration { get; private set; }

		[Tooltip("Pause duration (invisible) before the cycle repeats")]
		[field: SerializeField]
		public float PauseDuration { get; private set; }

		[Tooltip("Arrow alpha when fully visible")]
		[field: SerializeField]
		public float MaxAlpha { get; private set; }

		public float GetIdleDelay(int levelIndex)
		{
			return 0f;
		}
	}
}
