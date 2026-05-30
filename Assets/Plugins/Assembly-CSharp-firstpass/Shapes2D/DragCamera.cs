using UnityEngine;

namespace Shapes2D
{
	public class DragCamera : MonoBehaviour
	{
		private Vector3 anchor;

		private Vector3 origin;

		private bool dragging;

		private bool zoomed;

		private float lastClick;

		private void LateUpdate()
		{
		}
	}
}
