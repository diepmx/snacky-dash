using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PillGroupBox : MonoBehaviour
{
	[HideInInspector]
	public Collider2D Col;

	public int lockId;

	public bool priorityPillGroup;

	public bool lateActivation;

	public int lateActivationAtRespawnNumber;

	public bool risingBlockLockLater;

	[HideInInspector]
	public bool blockedByRisingBlock;

	private void Awake()
	{
	}
}
