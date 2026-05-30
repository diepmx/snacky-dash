using UnityEngine;

namespace JuicedUp.Features.Core.Layout
{
	public interface IBoundsProvider
	{
		bool GetBounds(out Bounds bounds);
	}
}
