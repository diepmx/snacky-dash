using System;
using UnityEngine;

public class TouchArrowPicker : MonoBehaviour
{
	public static Action<int> OnTouchingCannonArrow;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask hittableMask;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private bool TryGetTouchDown(out Vector2 screenPos)
	{
		screenPos = default(Vector2);
		return false;
	}
}
