using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class GuidanceArrowView : MonoBehaviour
	{
		[Tooltip("Optional. If left empty, sprite renderers are auto-collected from this GameObject and its children at Awake. Wire explicitly when the cascade order must be locked (e.g. bridge prefab).")]
		[SerializeField]
		private SpriteRenderer[] _spriteRenderers;

		public int CascadeSlots => 0;

		private void Awake()
		{
		}

		public void Setup(Vector3 worldPosition, float rotationZ)
		{
		}

		public float InsertFadeIn(Sequence sequence, float insertTime, float fadeInDuration, float cascadeDelay, float maxAlpha)
		{
			return 0f;
		}

		public void InsertFadeOut(Sequence sequence, float fadeOutInsertTime, float fadeOutDuration)
		{
		}

		public void Hide()
		{
		}

		private void SetAlpha(float alpha)
		{
		}

		public static float DirectionToRotationZ(DirectionPlayer dir)
		{
			return 0f;
		}
	}
}
