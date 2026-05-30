using UnityEngine;

public class CrateDeliverPoint : MonoBehaviour
{
	public int indexDeliverPoint;

	public GameObject idleRoot;

	public GameObject highlightRoot;

	public GameObject disabledRoot;

	public GameObject arrowCannonDeliver;

	public DeliveryPointState State { get; private set; }

	private void Start()
	{
	}

	public void ActivateArrowCannonDeliver()
	{
	}

	public void DeactivateArrowCannonDeliver()
	{
	}

	public void SetState(DeliveryPointState state)
	{
	}
}
