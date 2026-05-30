using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class TailSegment : MonoBehaviour
	{
		public Collider col;

		public int sortingOrder;

		[FormerlySerializedAs("segmentColor")]
		public PillKind segmentPillKind;

		public MeshRenderer meshSegment;

		[HideInInspector]
		public float tunnelBlend;

		public Transform visualRoot;

		[HideInInspector]
		public Vector3Int cachedCell;

		[HideInInspector]
		public bool hasCachedCell;

		public Transform pillTransform;

		[SerializeField]
		private PillController _pillController;

		public Vector3 Position { get; set; }

		public PositionStateRotation CurrentPose { get; set; }

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public void SetPillKind(PillKind kind)
		{
		}

		public void SetPillType(PillType type)
		{
		}

		public void TransformIntoFruit(bool beforeCrate)
		{
		}

		public void SetInitialSortingOrder(int _sortingOrder)
		{
		}

		public void Move(Vector3 newPosition)
		{
		}
	}
}
