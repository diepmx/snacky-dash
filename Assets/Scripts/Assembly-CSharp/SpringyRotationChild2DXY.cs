using UnityEngine;

public class SpringyRotationChild2DXY : MonoBehaviour
{
	[Tooltip("The transform that drives this part (usually the parent).")]
	public Transform parentToFollow;

	[Tooltip("How many degrees to tilt per unit of speed.")]
	public float tiltAmount;

	[Tooltip("How fast it springs back. Lower = more bouncy.")]
	public float smoothTime;

	[Tooltip("Maximum tilt angle (in degrees) from rest.")]
	public float maxAngle;

	private Vector3 _lastParentPos;

	private Vector3 _restLocalEuler;

	private Quaternion _restLocalRotation;

	private float _velX;

	private float _velY;

	private float _velZ;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void SmoothToAngles(Vector3 targetAngles)
	{
	}
}
