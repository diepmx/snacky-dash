using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[DisallowMultipleComponent]
public class UITextureScroller : MonoBehaviour
{
	private static readonly int MainTex;

	[Header("Target")]
	[SerializeField]
	private Graphic targetGraphic;

	[Header("Motion")]
	[Tooltip("Angle in degrees. 0=right, 90=up.")]
	[Range(0f, 360f)]
	public float angleDeg;

	[Tooltip("Speed in UV per second.")]
	public float speed;

	[Header("Tiling")]
	[Tooltip("How many times the texture repeats in X/Y.")]
	public Vector2 tiling;

	[Header("Options")]
	public bool unscaledTime;

	private Vector2 _offset;

	private Material _runtimeMat;

	private void Reset()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private static Vector2 DirFromAngle(float deg)
	{
		return default(Vector2);
	}

	private void EnsureMaterialInstance()
	{
	}

	private void ApplyTiling()
	{
	}

	private void ApplyOffset()
	{
	}
}
