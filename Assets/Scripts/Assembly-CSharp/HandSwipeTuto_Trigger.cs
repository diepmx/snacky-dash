using JuicedUp.Features.Core;
using UnityEngine;

public class HandSwipeTuto_Trigger : MonoBehaviour
{
	public DirectionPlayer dir_IfComeFrom_Up;

	public DirectionPlayer dir_IfComeFrom_Down;

	public DirectionPlayer dir_IfComeFrom_Left;

	public DirectionPlayer dir_IfComeFrom_Right;

	public HandAnimation tutoHand;

	private DirectionPlayer comeFrom;

	private void Start()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	public void SetComeFrom(DirectionPlayer dir)
	{
	}
}
