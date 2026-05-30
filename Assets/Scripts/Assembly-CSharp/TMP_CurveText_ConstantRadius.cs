using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TMP_Text))]
public class TMP_CurveText_ConstantRadius : MonoBehaviour
{
	public AnimationCurve curve;

	[Header("Arc")]
	[Tooltip("Constant arc radius (pixels for UGUI, units for 3D). Bigger = flatter arc.")]
	public float radius;

	[Tooltip("Maximum arc height to prevent extreme bending on very long text.")]
	public float maxHeight;

	public int baseCharacterCount;

	[Header("Rotation")]
	[Tooltip("1 = follow tangent exactly. >1 = more cartoon-like rotation.")]
	public float rotationMultiplier;

	[Range(0.0005f, 0.05f)]
	[Tooltip("Sampling step used to approximate curve derivative.")]
	public float derivativeStep;

	[Tooltip("Continuously update (useful if text changes at runtime).")]
	public bool liveUpdate;

	private TMP_Text _tmp;

	private void OnEnable()
	{
	}

	private void OnValidate()
	{
	}

	private void Update()
	{
	}

	public void Warp()
	{
	}
}
