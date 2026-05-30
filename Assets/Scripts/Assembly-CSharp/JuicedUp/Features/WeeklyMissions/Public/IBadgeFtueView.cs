using System;
using UnityEngine;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public interface IBadgeFtueView
	{
		event Action BadgeButtonClicked;

		void SetContentPosition(Vector3 position);
	}
}
