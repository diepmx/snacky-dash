using System;
using System.Collections.Generic;
using Cinemachine;
using EasyButtons;
using UnityEngine;

[Obsolete]
public class CameraSwitcher : MonoBehaviour
{
	[Header("Camera Settings")]
	public List<CameraGame> allCameras;

	public int defaultPriority;

	public int activePriority;

	[Header("Debug / Test")]
	public CameraGameType testCameraType;

	public CameraGameType currentCameraDebug;

	private Dictionary<CameraGameType, CinemachineVirtualCamera> dict_Cams;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnChunkInstantiated(CameraGameType type)
	{
	}

	private void Awake()
	{
	}

	public void SetActiveCamera(CameraGameType cameraToActivate)
	{
	}

	[Button("Switch Test Camera")]
	public void SwitchTestCamera()
	{
	}
}
