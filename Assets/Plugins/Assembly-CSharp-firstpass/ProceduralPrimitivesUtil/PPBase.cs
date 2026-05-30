using UnityEngine;

namespace ProceduralPrimitivesUtil
{
	[ExecuteInEditMode]
	public abstract class PPBase : MonoBehaviour
	{
		public Vector3 pivotOffset;

		public Vector3 rotation;

		public bool generateMappingCoords;

		public bool realWorldMapSize;

		public Vector2 UVOffset;

		public Vector2 UVTiling;

		public bool flipNormals;

		public bool smooth;

		private Collider m_collider;

		private MeshFilter m_meshFilter;

		private bool m_dirty;

		protected Mesh m_mesh;

		protected Quaternion m_rotation;

		protected PPMeshBuilder m_builder;

		public Mesh mesh => null;

		public bool isDirty => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		public GameObject CreateInstance()
		{
			return null;
		}

		protected abstract void CreateMesh();

		public void Apply()
		{
		}

		public void RefreshMesh()
		{
		}

		public bool HasCollider()
		{
			return false;
		}

		public Collider AddBoxCollider()
		{
			return null;
		}

		public Collider AddSphereCollider()
		{
			return null;
		}

		public Collider AddCapsuleCollider()
		{
			return null;
		}

		public Collider AddMeshCollider()
		{
			return null;
		}

		private void RefreshMeshFilter()
		{
		}

		private void RefreshCollider()
		{
		}
	}
}
