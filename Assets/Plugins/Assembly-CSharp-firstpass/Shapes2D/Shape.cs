using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Shapes2D
{
	[ExecuteInEditMode]
	public class Shape : MonoBehaviour, IMaterialModifier
	{
		public class ShapeDrawOrderComparer : IComparer<Shape>
		{
			public int Compare(Shape s1, Shape s2)
			{
				return 0;
			}
		}

		[Serializable]
		public class UserProps
		{
			[NonSerialized]
			public bool dirty;

			[NonSerialized]
			public bool polyMapNeedsRegen;

			[SerializeField]
			[FormerlySerializedAs("blur")]
			private float _blur;

			private bool _correctScaling;

			[SerializeField]
			[Range(0f, 360f)]
			private float _endAngle;

			[SerializeField]
			[FormerlySerializedAs("fillColor")]
			private Color _fillColor;

			[SerializeField]
			[FormerlySerializedAs("fillColor2")]
			private Color _fillColor2;

			[SerializeField]
			[FormerlySerializedAs("fillOffset")]
			private Vector2 _fillOffset;

			[SerializeField]
			private bool _fillPathLoops;

			[Range(0f, 360f)]
			[SerializeField]
			[FormerlySerializedAs("fillRotation")]
			private float _fillRotation;

			[SerializeField]
			[FormerlySerializedAs("fillScale")]
			private Vector2 _fillScale;

			[SerializeField]
			[FormerlySerializedAs("fillTexture")]
			private Texture2D _fillTexture;

			[SerializeField]
			[FormerlySerializedAs("fillType")]
			private FillType _fillType;

			[SerializeField]
			[FormerlySerializedAs("gradientAxis")]
			private GradientAxis _gradientAxis;

			[SerializeField]
			[FormerlySerializedAs("gradientStart")]
			[Range(0f, 1f)]
			private float _gradientStart;

			[SerializeField]
			[FormerlySerializedAs("gradientType")]
			private GradientType _gradientType;

			[SerializeField]
			[FormerlySerializedAs("gridSize")]
			private float _gridSize;

			[SerializeField]
			private Vector2 _innerCutout;

			[SerializeField]
			private bool _invertArc;

			[SerializeField]
			[FormerlySerializedAs("lineSize")]
			private float _lineSize;

			[HideInInspector]
			[FormerlySerializedAs("numSides")]
			public int _obsoleteNumSides;

			[SerializeField]
			[FormerlySerializedAs("outlineColor")]
			private Color _outlineColor;

			[SerializeField]
			[FormerlySerializedAs("outlineSize")]
			private float _outlineSize;

			[SerializeField]
			private PathSegment[] _pathSegments;

			[SerializeField]
			private float _pathThickness;

			[SerializeField]
			private PolygonPreset _polygonPreset;

			[SerializeField]
			[FormerlySerializedAs("_vertices")]
			private Vector2[] _polyVertices;

			[SerializeField]
			[FormerlySerializedAs("roundness")]
			private float _roundness;

			[SerializeField]
			[FormerlySerializedAs("roundnessBottomLeft")]
			private float _roundnessBottomLeft;

			[SerializeField]
			[FormerlySerializedAs("roundnessBottomRight")]
			private float _roundnessBottomRight;

			[SerializeField]
			[FormerlySerializedAs("roundnessPerCorner")]
			private bool _roundnessPerCorner;

			[SerializeField]
			[FormerlySerializedAs("roundnessTopLeft")]
			private float _roundnessTopLeft;

			[SerializeField]
			[FormerlySerializedAs("roundnessTopRight")]
			private float _roundnessTopRight;

			[SerializeField]
			[FormerlySerializedAs("shapeType")]
			private ShapeType _shapeType;

			[SerializeField]
			[Range(0f, 360f)]
			private float _startAngle;

			[SerializeField]
			[FormerlySerializedAs("triangleOffset")]
			[Range(0f, 1f)]
			private float _triangleOffset;

			[SerializeField]
			private bool _usePolygonMap;

			public float blur
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool correctScaling
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float endAngle
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Color fillColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color fillColor2
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Vector2 fillOffset
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public bool fillPathLoops
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float fillRotation
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Vector2 fillScale
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public Texture2D fillTexture
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public FillType fillType
			{
				get
				{
					return default(FillType);
				}
				set
				{
				}
			}

			public GradientAxis gradientAxis
			{
				get
				{
					return default(GradientAxis);
				}
				set
				{
				}
			}

			public float gradientStart
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public GradientType gradientType
			{
				get
				{
					return default(GradientType);
				}
				set
				{
				}
			}

			public float gridSize
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Vector2 innerCutout
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public bool invertArc
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float lineSize
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Color outlineColor
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public float outlineSize
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public PathSegment[] pathSegments
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float pathThickness
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public PolygonPreset polygonPreset
			{
				get
				{
					return default(PolygonPreset);
				}
				set
				{
				}
			}

			public Vector2[] polyVertices
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float roundness
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float roundnessBottomLeft
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float roundnessBottomRight
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool roundnessPerCorner
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float roundnessTopLeft
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float roundnessTopRight
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public ShapeType shapeType
			{
				get
				{
					return default(ShapeType);
				}
				set
				{
				}
			}

			public float startAngle
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float triangleOffset
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool usePolygonMap
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		protected class ShaderProps
		{
			public float xScale;

			public float yScale;

			public ShapeType shapeType;

			public float outlineSize;

			public float blur;

			public Color outlineColor;

			public FillType fillType;

			public Color fillColor;

			public Color fillColor2;

			public float fillRotation;

			public Vector2 fillOffset;

			public Vector2 fillScale;

			public GradientType gradientType;

			public GradientAxis gradientAxis;

			public float gradientStart;

			public Texture2D fillTexture;

			public float gridSize;

			public float lineSize;

			public Vector4 roundnessVec;

			public Vector4 innerRadii;

			public float arcMinAngle;

			public float arcMaxAngle;

			public bool invertArc;

			public bool useArc;

			public bool correctScaling;

			public float triangleOffset;

			public int numPolyVerts;

			public Vector4[] polyVertices;

			public bool usePolygonMap;

			public Texture2D polyMap;

			public float pathThickness;

			public int numPathSegments;

			public Vector4[] pathPoints;

			public bool fillPathLoops;
		}

		public static readonly int MaxPolygonVertices;

		public static readonly int PolyMapResolution;

		public static readonly int MaxPathSegments;

		private Material material;

		private SpriteRenderer spriteRenderer;

		private Image image;

		private RectTransform rectTransform;

		private Vector3 computedScale;

		private Rect computedRect;

		public UserProps settings;

		private ShaderProps shaderSettings;

		[HideInInspector]
		public bool wasConverted;

		[HideInInspector]
		public Vector3 preConvertedScale;

		private static string[] _ShaderVertexVarNames;

		private static string[] _ShaderPointsVarNames;

		private static string[] ShaderVertexVarNames => null;

		private static string[] ShaderPointsVarNames => null;

		private static Vector2[] GetVerticesForPreset(PolygonPreset preset)
		{
			return null;
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private Material GetBaseMaterial(ShapeType st)
		{
			return null;
		}

		public void Configure()
		{
		}

		private void SetKeyword(Material material, string keyword, bool value)
		{
		}

		private void ApplyShaderPropertiesToMaterial(Material material, bool disableBlending = false)
		{
		}

		private void GetRectTransformWorldCorners(out Vector3 topLeft, out Vector3 topRight, out Vector3 bottomLeft, out Vector3 bottomRight)
		{
			topLeft = default(Vector3);
			topRight = default(Vector3);
			bottomLeft = default(Vector3);
			bottomRight = default(Vector3);
		}

		public Vector2 GetScale()
		{
			return default(Vector2);
		}

		public Vector2 GetSize()
		{
			return default(Vector2);
		}

		private void ComputeShaderProperties()
		{
		}

		private int FindPathLoop(Vector2 current, Vector2 seek, int skipSegment, int count, List<Vector2> visited, int iterations)
		{
			return 0;
		}

		private bool SegmentIsInLoop(int segmentIndex)
		{
			return false;
		}

		private bool SegmentIsOpen(int i)
		{
			return false;
		}

		Material IMaterialModifier.GetModifiedMaterial(Material oldMaterial)
		{
			return null;
		}

		public void ComputeAndApply(bool disableBlending = false)
		{
		}

		private void OnValidate()
		{
		}

		private void Update()
		{
		}

		public bool IsUIComponent()
		{
			return false;
		}

		private Vector2 BiLerp(Vector3[] corners, Vector2 normalized)
		{
			return default(Vector2);
		}

		private Vector2 NormalizePointInRect(Vector3[] corners, Vector3 point)
		{
			return default(Vector2);
		}

		public bool PointIsWithinShapeBounds(Vector3 point)
		{
			return false;
		}

		public Vector3[] GetPolygonWorldVertices()
		{
			return null;
		}

		public void SetPolygonWorldVertices(Vector3[] verts3D)
		{
		}

		public PathSegment[] GetPathWorldSegments()
		{
			return null;
		}

		public void SetPathWorldSegments(PathSegment[] worldSegments)
		{
		}

		private void CheckForShaderReset()
		{
		}

		private void OnWillRenderObject()
		{
		}

		private bool UIShapeIsMasked(Shape shape, bool includeSelf)
		{
			return false;
		}

		private bool UIShapeIsRectMasked(Shape shape, bool includeSelf)
		{
			return false;
		}

		private Vector2 GetWorldCenter()
		{
			return default(Vector2);
		}

		public Bounds GetShapeBounds()
		{
			return default(Bounds);
		}

		public Vector2 GetShapePixelSize(float pixelsPerUnit = 100f)
		{
			return default(Vector2);
		}

		public List<Shape> GetShapesInDrawOrder()
		{
			return null;
		}

		public Texture2D DrawToTexture2D(Camera cam, int w, int h)
		{
			return null;
		}

		public List<UnityEngine.Object> GetUndoObjects()
		{
			return null;
		}

		public void SetAsSprite(Sprite sprite, Material spriteDefaultMaterial)
		{
		}

		public Vector2 GetPivot()
		{
			return default(Vector2);
		}

		public Vector3[] GetWorldCorners(Vector3[] corners)
		{
			return null;
		}

		public void RestoreFromConversion()
		{
		}

		public bool IsConfigured()
		{
			return false;
		}
	}
}
