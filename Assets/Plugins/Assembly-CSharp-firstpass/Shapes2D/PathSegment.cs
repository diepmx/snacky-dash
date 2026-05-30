using System;
using UnityEngine;

namespace Shapes2D
{
	[Serializable]
	public struct PathSegment
	{
		public Vector3 p0;

		public Vector3 p1;

		public Vector3 p2;

		public Vector3 midpoint => default(Vector3);

		public PathSegment(Vector2 p0, Vector2 p1, Vector3 p2)
		{
			this.p0 = default(Vector3);
			this.p1 = default(Vector3);
			this.p2 = default(Vector3);
		}

		public PathSegment(Vector2 p0, Vector2 p2)
		{
			this.p0 = default(Vector3);
			p1 = default(Vector3);
			this.p2 = default(Vector3);
		}

		public void Clamp()
		{
		}

		public void MakeLinear()
		{
		}
	}
}
