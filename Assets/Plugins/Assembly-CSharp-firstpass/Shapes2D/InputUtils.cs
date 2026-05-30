using UnityEngine;

namespace Shapes2D
{
	public class InputUtils
	{
		public static Vector3 InputToWorldPosition(Vector2 inputPos)
		{
			return default(Vector3);
		}

		private static bool WasMouseDown(int button)
		{
			return false;
		}

		private static bool WasFingerDown()
		{
			return false;
		}

		private static Vector2 FirstTouchPosition()
		{
			return default(Vector2);
		}

		public static bool MouseDownOrTap()
		{
			return false;
		}

		public static Vector2 MouseOrTapPosition()
		{
			return default(Vector2);
		}
	}
}
