using UnityEngine;

public class DestinationPointInCrate : MonoBehaviour
{
	public bool IsFilled { get; set; }

	public Vector3 IdleLocalPositionInParent { get; set; }

	public Vector3 IdleLocalScaleInParent { get; set; }

	public Quaternion IdleLocalRotationInParent { get; set; }
}
