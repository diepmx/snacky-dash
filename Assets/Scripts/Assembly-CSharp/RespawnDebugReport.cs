using System;
using System.Collections.Generic;
using JuicedUp.Features.Core;

[Serializable]
public class RespawnDebugReport
{
	public int cycleIndex;

	public int selectedGroups;

	public int fullGroupsAccepted;

	public int groupsRejectedByBudget;

	public int singlesPlaced;

	public string note;

	public Dictionary<PillKind, int> budgetAfter;

	public Dictionary<PillKind, int> budgetBefore;

	public Dictionary<PillKind, int> placedCommon;

	public Dictionary<PillKind, int> placedRare;

	public Dictionary<PillKind, int> placedTotal;

	public Dictionary<PillKind, int> requestedValue;
}
