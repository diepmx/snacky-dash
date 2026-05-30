using System;
using System.Collections.Generic;

[Serializable]
public class PillsGroup
{
	public string name;

	public int pillsGroupId;

	public List<PillController> pillMasters;

	public bool isUnlocked;

	public bool priorityPillGroup;

	[NonSerialized]
	public PillGroupBox associatedPillGroupBox;
}
