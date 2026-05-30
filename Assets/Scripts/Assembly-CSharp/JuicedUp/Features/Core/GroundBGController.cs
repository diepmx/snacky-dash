using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class GroundBGController : MonoBehaviour
	{
		[Header("Top Anchors")]
		[SerializeField]
		private Transform _topLeft;

		[SerializeField]
		private Transform _topCenter;

		[SerializeField]
		private Transform _topRight;

		[Header("Bottom Anchors")]
		[SerializeField]
		private Transform _bottomLeft;

		[SerializeField]
		private Transform _bottomCenter;

		[SerializeField]
		private Transform _bottomRight;

		[Header("Infinity Grass Planes")]
		[SerializeField]
		private Transform _grassPlaneLeft;

		[SerializeField]
		private Transform _grassPlaneRight;

		[SerializeField]
		private Transform _grassPlaneTop;

		[SerializeField]
		private Transform _grassPlaneBottom;

		private const float PlaneOutwardOffset = 19.5f;

		private const float PlaneLocalY = 0.71f;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnStartingGame()
		{
		}

		private void PositionGrassPlanes(float minX, float maxX, float minZ, float maxZ, float centerX)
		{
		}

		private void SetLocalXYZ(Transform targetTransform, float localX, float localY, float localZ)
		{
		}

		private static void SetPosition(Transform targetTransform, float x, float y, float z)
		{
		}
	}
}
