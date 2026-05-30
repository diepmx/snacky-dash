using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class DarkOverlayController : MonoBehaviour
	{
		[Tooltip("Tag used to auto-discover hole objects in the scene. Leave empty to disable auto-discovery.")]
		[SerializeField]
		private string _holeTag;

		[Tooltip("Material assigned to the overlay renderer. Must use the DarkOverlayMasked shader.")]
		[SerializeField]
		private Material _maskedOverlayMaterial;

		[Tooltip("Material assigned to each hole's child renderer. Must use the DarkOverlayStencilWriter shader.")]
		[SerializeField]
		private Material _stencilWriterMaterial;

		[Tooltip("Default sprite used by discovered holes when they don't specify their own.")]
		[SerializeField]
		private Sprite _defaultMaskSprite;

		[Tooltip("Scan the scene for holes during Awake.")]
		[SerializeField]
		private bool _autoDiscoverOnAwake;

		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		private readonly HashSet<DarkOverlayHole> _activeHoles;

		private void Awake()
		{
		}

		public void RefreshHoles()
		{
		}

		public DarkOverlayHole RegisterHole(Transform target)
		{
			return null;
		}

		public bool UnregisterHole(Transform target)
		{
			return false;
		}
	}
}
