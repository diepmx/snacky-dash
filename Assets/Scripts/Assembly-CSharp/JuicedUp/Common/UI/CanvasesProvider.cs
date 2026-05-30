using UnityEngine;

namespace JuicedUp.Common.UI
{
	public class CanvasesProvider : ICanvasesProvider
	{
		public Canvas MainSceneCanvas { get; }

		public CanvasesProvider(Canvas mainSceneCanvas)
		{
		}
	}
}
