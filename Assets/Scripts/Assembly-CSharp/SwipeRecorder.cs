using JuicedUp.Features.Core;
using UnityEngine;

public class SwipeRecorder : MonoBehaviour
{
	[SerializeField]
	private DirectionPlayer swipeRecorded;

	[SerializeField]
	private float elapsed;

	public float maxTimeRecordSwipe;

	private void Update()
	{
	}

	public void AddDirectionToRecordSwipe(DirectionPlayer directionAdded)
	{
	}

	public void ResetRecordSwipe()
	{
	}

	public DirectionPlayer DirectionRecorded()
	{
		return default(DirectionPlayer);
	}
}
