using System.Collections.Generic;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Features.Core.Layout;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class TutorialFocusService
	{
		private const int TutorialLayerIndex = 13;

		private const float DimmedBoosterAlpha = 0.03f;

		private static readonly Vector2 HighlightHoleSize;

		private readonly Dictionary<GameObject, int> _originalLayers;

		private readonly HashSet<GameObject> _highlightedHoles;

		private readonly LevelCameraFitter _levelCameraFitter;

		private readonly DarkOverlayController _overlayController;

		private readonly Camera _focusCamera;

		private readonly BoosterButtonUI[] _boosterButtons;

		private readonly float[] _originalBoosterAlphas;

		private bool _boosterAlphasDimmed;

		public TutorialFocusService(LevelCameraFitter levelCameraFitter, DarkOverlayController overlayController, Camera focusCamera, BoosterButtonUI[] boosterButtons)
		{
		}

		public void EnableDimming()
		{
		}

		public void DisableDimming()
		{
		}

		private void SetDarkOverlayActive(bool active)
		{
		}

		public void HighlightObject(GameObject target)
		{
		}

		public void HighlightObjectHole(GameObject target, Vector2 localOffset = default(Vector2))
		{
		}

		public void RestoreAllLayers()
		{
		}

		public void UndimBoosterButton(BoosterId id)
		{
		}

		private void DimBoosterButtons()
		{
		}

		private void RestoreBoosterButtons()
		{
		}

		private void SetLayerRecursive(GameObject target, int layer, bool rememberOriginal)
		{
		}

		private void SyncFocusCameraToGameplayCamera()
		{
		}
	}
}
