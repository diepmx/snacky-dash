using System.Collections.Generic;
using UnityEngine;

namespace HighlightPlus
{
	[DefaultExecutionOrder(100)]
	[ExecuteInEditMode]
	public class HighlightEffectBlocker : MonoBehaviour
	{
		public BlockerTargetOptions include;

		public LayerMask layerMask;

		public string nameFilter;

		public bool useRegEx;

		public bool blockOutlineAndGlow;

		public bool blockOverlay;

		private Material blockerOutlineAndGlowMat;

		private Material blockerOverlayMat;

		private Material blockerAllMat;

		private List<Renderer> renderers;

		private void OnEnable()
		{
		}

		public void Refresh()
		{
		}

		private void Update()
		{
		}
	}
}
