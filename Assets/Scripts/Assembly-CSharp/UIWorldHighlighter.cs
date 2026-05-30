using System;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldHighlighter : MonoBehaviour
{
	[Serializable]
	public class Target
	{
		public Transform target3D;

		public Vector3 worldOffset;
	}

	[Header("Refs")]
	[SerializeField]
	private Camera worldCam;

	[SerializeField]
	private RectTransform canvasRect;

	[SerializeField]
	private RectTransform highlightPrefab;

	[Header("Targets")]
	[SerializeField]
	private List<Target> targets;

	[Header("Behavior")]
	[SerializeField]
	private bool hideIfBehindCamera;

	private readonly Dictionary<Transform, RectTransform> uiByTarget;

	private Canvas _canvas;

	private Camera _uiCam;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void Rebuild()
	{
	}

	public void SetTargets(IEnumerable<Target> newTargets)
	{
	}

	public void AddTarget(Transform target, Vector3 offset = default(Vector3))
	{
	}
}
