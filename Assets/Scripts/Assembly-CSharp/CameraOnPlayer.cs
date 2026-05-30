using System;
using Cinemachine;
using UnityEngine;

[Obsolete]
public class CameraOnPlayer : MonoBehaviour
{
	public CinemachineVirtualCamera virtualCamera;

	private CinemachineFramingTransposer componentBase;

	public float defaultDistance;

	public float addedCamDistPerSnakeNode;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void UpdateCamera(int numberOfTailSegments)
	{
	}
}
