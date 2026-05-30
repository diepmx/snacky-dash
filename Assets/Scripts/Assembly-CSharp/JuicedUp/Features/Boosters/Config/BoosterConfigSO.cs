using System;
using System.Collections.Generic;
using DG.Tweening;
using JuicedUp.Common.Economy.Public.Data;
using UnityEngine;

namespace JuicedUp.Features.Boosters.Config
{
	[CreateAssetMenu(menuName = "JuicedUp/Boosters/Booster Config", fileName = "BoosterConfig")]
	public sealed class BoosterConfigSO : ScriptableObject
	{
		[Serializable]
		public sealed class ForcedBoosterTutorialEntry
		{
			[SerializeField]
			private BoosterId _boosterId;

			[SerializeField]
			private ForcedBoosterFlowType _flowType;

			[SerializeField]
			[Tooltip("Tail length threshold that must be reached before the Delayed spotlight begins. Ignored for Immediate flow.")]
			[Min(1f)]
			private int _delayedTailLengthThreshold;

			public BoosterId BoosterId => default(BoosterId);

			public ForcedBoosterFlowType FlowType => default(ForcedBoosterFlowType);

			public int DelayedTailLengthThreshold => 0;
		}

		[SerializeField]
		private List<ForcedBoosterTutorialEntry> _forcedTutorialEntries;

		[SerializeField]
		private string _tutorialPopupPrefabPath;

		[Header("Shuffle Booster Vortex VFX")]
		[Tooltip("Particle System prefab spawned (and destroyed on dispose) for the Shuffle vortex VFX. Played after the Shuffle pre-use animation completes and before pills are reshuffled. The prefab is instantiated lazily on first use and snapped to the level bounds centre. Leave null to disable the VFX (the synchronous reshuffle still runs).")]
		[SerializeField]
		private ParticleSystem _shuffleVortexVfxPrefab;

		[Tooltip("Seconds the Shuffle booster waits for the 'Vortex Big2' particle system to wind up before reshuffling pills. The particle system keeps playing through the shuffle and runs its own duration (no manual stop).")]
		[SerializeField]
		[Min(0f)]
		private float _shuffleVortexPreShuffleDelaySeconds;

		[Header("Boomerang (Cannon) Booster Flight VFX")]
		[Tooltip("VFX prefab parented to each fruit flying during a boomerang-triggered delivery. CrateView builds a small object pool internally on first use. Leave null to disable the VFX (the scale bump still applies independently).")]
		[SerializeField]
		private GameObject _boomerangFlightVfxPrefab;

		[Tooltip("Override duration (seconds) for the fruit's flight to the crate when triggered by the boomerang booster. Set to 0 or less to reuse the crate's FruitsJumpToCrateDuration. Both the flight motion and the crate-lid absorption timing use this value, so they stay in sync.")]
		[SerializeField]
		[Min(0f)]
		private float _boomerangFlightDuration;

		[Tooltip("Multiplier applied to the fruit's interpolated scale at the peak of the boomerang flight arc (t = 0.5). 1.0 disables the bump; 1.5 = 150% peak size. The bump rises and falls following the BoomerangFlightScaleEase below, so the fruit returns to its natural end scale on landing. The VFX prefab itself is wired in LevelLifetimeScope.")]
		[SerializeField]
		[Min(1f)]
		private float _boomerangFlightMaxScaleMultiplier;

		[Tooltip("DOTween ease applied to the boomerang fruit's flight position (XY interpolation and the parabolic Z arc). OutQuad / OutCubic feel like a deliberate throw; InOutBack adds anticipation. The arc peak stays at the midpoint of the eased trajectory.")]
		[SerializeField]
		private Ease _boomerangFlightPositionEase;

		[Tooltip("DOTween ease applied to the rise AND fall halves of the boomerang scale bump (0 → peak → 0 in normalised time). OutBack / OutBounce give the punchy 'rises high then falls to ground' feel. OutElastic feels jelly-like. Linear gives a clean triangle.")]
		[SerializeField]
		private Ease _boomerangFlightScaleEase;

		[Header("Boomerang (Cannon) Booster Sky Gather")]
		[Tooltip("Per-fruit world-space offset applied during the 'rise to sky' phase. Default uses -Z as 'up' to match the existing flight arc convention (worldPos.z -= ...). Tune Y/-Z to lift fruits visually before they fly to crates.")]
		[SerializeField]
		private Vector3 _boomerangRiseOffset;

		[Tooltip("Time (seconds) for each fruit to travel from its detach position to its sky position.")]
		[SerializeField]
		[Min(0.01f)]
		private float _boomerangRiseDuration;

		[Tooltip("DOTween ease applied to the rise motion. OutCubic / OutQuad feel like a gentle lift; OutBack adds a small overshoot at the apex.")]
		[SerializeField]
		private Ease _boomerangRiseEase;

		[Tooltip("Time (seconds) the gathered fruits hover at the sky before sequential launches start. Measured from the moment the LAST fruit reaches its sky position.")]
		[SerializeField]
		[Min(0f)]
		private float _boomerangSkyHoverDuration;

		[Tooltip("Micro-delay (seconds) between the start of each sequential launch from the sky to a crate. Smaller = tighter chain, larger = more staggered drama.")]
		[SerializeField]
		[Min(0f)]
		private float _boomerangLaunchInterval;

		[Tooltip("Maximum time (seconds) the sequential launch phase will wait for a newly-active crate to finish sliding into its lane position before launching the next fruit at it. Prevents fruits aimed at the second/third crate in a chain from flying off-screen while the previous crate is still being removed. Set to 0 to disable the wait (not recommended for columns with multiple crates).")]
		[SerializeField]
		[Min(0f)]
		private float _boomerangCrateTransitionMaxWait;

		public string TutorialPopupPrefabPath => null;

		public ParticleSystem ShuffleVortexVfxPrefab => null;

		public float ShuffleVortexPreShuffleDelaySeconds => 0f;

		public GameObject BoomerangFlightVfxPrefab => null;

		public float BoomerangFlightDuration => 0f;

		public float BoomerangFlightMaxScaleMultiplier => 0f;

		public Ease BoomerangFlightPositionEase => default(Ease);

		public Ease BoomerangFlightScaleEase => default(Ease);

		public Vector3 BoomerangRiseOffset => default(Vector3);

		public float BoomerangRiseDuration => 0f;

		public Ease BoomerangRiseEase => default(Ease);

		public float BoomerangSkyHoverDuration => 0f;

		public float BoomerangLaunchInterval => 0f;

		public float BoomerangCrateTransitionMaxWait => 0f;

		public ForcedBoosterTutorialEntry GetEntry(BoosterId id)
		{
			return null;
		}
	}
}
