using UnityEngine;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(menuName = "JuicedUp/Crate Visual Config", fileName = "CrateVisualConfig")]
	public class CrateVisualConfig : ScriptableObject
	{
		[Header("Prefabs")]
		public GameObject CratePrefab9;

		public GameObject CratePrefab18;

		public GameObject CratePrefab27;

		[Header("Icons")]
		public bool UseIconsWithOutline;

		[Header("Animation Timing")]
		public float CrateArriveDelay;

		public float CrateArriveDuration;

		public float CratePauseBeforeDeliver;

		public float CrateDeliverDelay;

		public float CrateDeliverDuration;

		public float FruitsJumpToCrateDuration;

		[Header("Next Crate Sign (Optional)")]
		[Tooltip("If null, no sign is spawned. Leave empty for the truck variant.")]
		public GameObject NextCrateSignPrefab;

		public float GetJumpToCrateDuration(bool isBoomerang, float boomerangFlightDuration)
		{
			return 0f;
		}
	}
}
