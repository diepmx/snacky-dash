using UnityEngine;

namespace ProceduralPrimitivesUtil.Demo
{
	[ExecuteInEditMode]
	public class WireframeRenderer : MonoBehaviour
	{
		private enum RendererType
		{
			MeshRenderer = 0,
			SkinnedMeshRenderer = 1
		}

		public bool ShowBackFaces;

		public Color LineColor;

		public bool Shaded;

		[SerializeField]
		[HideInInspector]
		private Renderer originalRenderer;

		[SerializeField]
		[HideInInspector]
		private Mesh processedMesh;

		[SerializeField]
		[HideInInspector]
		private Renderer wireframeRenderer;

		[SerializeField]
		[HideInInspector]
		private Material wireframeMaterialCull;

		[SerializeField]
		[HideInInspector]
		private Material wireframeMaterialNoCull;

		[SerializeField]
		[HideInInspector]
		private RendererType originalRendererType;

		private void Awake()
		{
		}

		public void SetMeshDirty()
		{
		}

		private void OnDestroy()
		{
		}

		private void Validate()
		{
		}

		private Mesh GetOriginalMesh()
		{
			return null;
		}

		private void UpdateWireframeRendererMesh()
		{
		}

		private void CreateWireframeRenderer()
		{
		}

		private void OnValidate()
		{
		}

		private void CreateMaterials()
		{
		}

		private void UpdateWireframeRendererMaterial()
		{
		}

		private void UpdateLineColor()
		{
		}

		private void UpateShaded()
		{
		}

		private Material CreateWireframeMaterial(bool cull)
		{
			return null;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private Mesh GetProcessedMesh(Mesh mesh)
		{
			return null;
		}
	}
}
