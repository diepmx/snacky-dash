using JuicedUp.Features.Core;
using UnityEngine;

public interface IMoveReceiver
{
	bool IsMoving { get; }

	bool IsAutoTurning { get; }

	DirectionPlayer CurrentDirection { get; }

	int TailLength { get; }

	Vector3 Position { get; }

	bool CanMove(DirectionPlayer dir, bool shouldAnim);

	bool TryRequestMove(DirectionPlayer dir, bool playFeedbackIfBlocked = true);
}
