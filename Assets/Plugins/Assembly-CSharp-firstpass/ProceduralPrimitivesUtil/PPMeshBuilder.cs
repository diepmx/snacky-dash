using System.Collections.Generic;
using UnityEngine;

namespace ProceduralPrimitivesUtil
{
	public class PPMeshBuilder
	{
		public List<Vector3> m_vertices;

		public List<int> m_triangles;

		public List<Vector3> m_normals;

		public List<Vector2> m_uv;

		public void Apply(Mesh mesh)
		{
		}

		public void Clear()
		{
		}

		public static float PointLineDistance(Vector3 vp, Vector3 v)
		{
			return 0f;
		}

		public static float PointLineProjectionn(Vector3 vp, Vector3 v)
		{
			return 0f;
		}

		public void CreateTriangle(Vector3 p0, Vector3 p1, Vector3 p2)
		{
		}

		public void CreateTriangle(Vector3 p0, Vector3 p1, Vector3 p2, Vector2 p0uv, Vector2 p1uv, Vector2 p2uv)
		{
		}

		public void CreateQuad(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
		}

		public void CreateQuad(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Vector2 p0uv, Vector2 p1uv, Vector2 p2uv, Vector2 p3uv)
		{
		}

		public void CreateTriangle(Vector3 center, Vector3 forward, Vector3 right, float width, float length, float offset, int seg, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateTriangle(Vector3 center, Vector3 forward, Vector3 right, float width, float length, float offset, int seg, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreateTriangle(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 normal, int seg, bool generateUV, Vector2 uvOffset, Vector2 uvTiling)
		{
		}

		public void CreateTriangle(Vector3 center, Vector3 forward, Vector3 right, float width, float length, float offset, int segW, int segL, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateTriangle(Vector3 center, Vector3 forward, Vector3 right, float width, float length, float offset, int segW, int segL, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreateTriangle(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 normal, int segW, int segL, bool generateUV, Vector2 uvOffset, Vector2 uvTiling)
		{
		}

		public void CreatePlane(Vector3 center, Vector3 forward, Vector3 right, float width, float length, int segW, int segL, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreatePlane(Vector3 center, Vector3 forward, Vector3 right, float width, float length, int segW, int segL, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreatePlane(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 normal, int segW, int segL, bool generateUV, Vector2 uvOffset, Vector2 uvTiling)
		{
		}

		public void CreateTrapezoid(Vector3 center, Vector3 forward, Vector3 right, float width1, float width2, float length, float offset, int segW, int segL, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateTrapezoid(Vector3 center, Vector3 forward, Vector3 right, float width1, float width2, float length, float offset, int segW, int segL, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreateTrapezoid(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 normal, int segW, int segL, bool generateUV, Vector2 uvOffset, Vector2 uvTiling)
		{
		}

		public void CreateCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreateHemiCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool hemiCircle, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, bool flip, bool isSector = false)
		{
		}

		public void CreateHemiCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool hemiCircle, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool isSector = false)
		{
		}

		public void CreateCircle(Vector3[] points, Vector2[] uvs, Vector3 center, Vector3 normal, int seg, Vector2 uvOffset, Vector2 uvTiling, float centerUVOffset = 0f)
		{
		}

		public void CreateRing(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateRing(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip)
		{
		}

		public void CreateRing(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip)
		{
		}

		public void CreateRing(Vector3[] points, Vector2[] uvs, Vector3 center, Vector3 normal, float ratio, int seg, Vector2 uvOffset, Vector2 uvTiling, float centerUVOffset = 0f)
		{
		}

		public void CreateHemiRing(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool hemiCircle, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, bool flip, bool isSector = false)
		{
		}

		public void CreateHemiRing(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool hemiCircle, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool isSector = false)
		{
		}

		public void CreateRing(Vector3[] points, Vector3[] points2, Vector2[] uvs, Vector2[] uvs2, Vector3 center, Vector3 normal, int seg, Vector2 uvOffset, Vector2 uvTiling, float centerUVOffset = 0f)
		{
		}

		public void CreateTorus(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip, bool smooth, float sectionSliceFrom = 0f, float sectionSliceTo = 360f)
		{
		}

		public void CreateTorus(Vector3 center, Vector3 forward, Vector3 right, float radius1, float radius2, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth, float sectionSliceFrom, float sectionSliceTo)
		{
		}

		public void CreateTorus(Vector3[][] points, Vector3[] centers, int seg, bool generateUV, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateCylinder(Vector3 center, Vector3 forward, Vector3 right, float height, float radius, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip, bool smooth)
		{
		}

		public void CreateCylinder(Vector3 center, Vector3 forward, Vector3 right, float height, float radius, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateCylinder(Vector3[] pDown, Vector3[] pUp, Vector3 centerDown, Vector3 centerUp, int seg, bool generateUV, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateCone(Vector3 center, Vector3 forward, Vector3 right, float height, float radius1, float radius2, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip, bool smooth)
		{
		}

		public void CreateCone(Vector3 center, Vector3 forward, Vector3 right, float height, float radius1, float radius2, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateCone(Vector3 centerDown, Vector3 centerUp, Vector3 forward, Vector3 right, float height, float radius1, float radius2, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, bool flip, bool smooth)
		{
		}

		public void CreateCone(Vector3 centerDown, Vector3 centerUp, Vector3 forward, Vector3 right, float height, float radius1, float radius2, int sides, int segHeight, bool sliceOn, float sliceFrom, float sliceTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateCone(Vector3[] pDown, Vector3[] pUp, Vector3 centerDown, Vector3 centerUp, Vector3 up, int seg, bool generateUV, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateSphere(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool hemiSphere, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, bool flip, bool smooth)
		{
		}

		public void CreateSphere(Vector3 center, Vector3 forward, Vector3 right, float radius, int sides, int seg, bool sliceOn, float sliceFrom, float sliceTo, bool hemiSphere, float cutFrom, float cutTo, bool generateUV, bool realWorldMapSize, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth)
		{
		}

		public void CreateSphere(Vector3[][] points, Vector3 center, bool generateUV, Vector2 uvOffset, Vector2 uvTiling, bool flip, bool smooth, float rFrom, float rTo)
		{
		}
	}
}
