using UnityEngine;

namespace JuicedUp.Features.Core
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	public class DarkOverlayHole : MonoBehaviour
	{
		private const string HoleChildName = "__DarkOverlayHole";

		private const float DefaultAlphaCutoff = 0.1f;

		private const int WriterSortingOffset = -1;

		[Tooltip("Sprite used as the hole shape. When left null, the controller's default sprite is used.")]
		[SerializeField]
		private Sprite _holeSprite;

		[Tooltip("World-space size of the hole (uses 9-slice when the sprite has borders).")]
		[SerializeField]
		private Vector2 _size;

		[Tooltip("Local-space offset of the hole relative to this transform.")]
		[SerializeField]
		private Vector2 _localOffset;

		[Tooltip("Alpha threshold at which a sprite texel is considered a hole.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _alphaCutoff;

		[SerializeField]
		[HideInInspector]
		private Material _writerMaterial;

		[SerializeField]
		[HideInInspector]
		private int _sortingLayerID;

		[SerializeField]
		[HideInInspector]
		private int _sortingOrder;

		private SpriteRenderer _holeRenderer;

		private static readonly int CutoffPropertyId;

		public Vector2 Size
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Sprite HoleSprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 LocalOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public void BindTo(SpriteRenderer overlayRenderer, Material writerMaterial, Sprite fallbackSprite)
		{
		}

		public void SetHoleActive(bool active)
		{
		}

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}

		private void EnsureHoleRenderer()
		{
		}

		private void ApplyHoleSettings()
		{
		}
	}
}
