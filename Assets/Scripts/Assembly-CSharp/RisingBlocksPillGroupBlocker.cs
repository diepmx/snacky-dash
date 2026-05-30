using System.Collections.Generic;
using EasyButtons;
using JuicedUp.Features.Core;
using UnityEngine;

public class RisingBlocksPillGroupBlocker : MonoBehaviour
{
	[Header("Refs")]
	public PillManager pillManager;

	[Header("Associations")]
	public List<RBPGAssociation> rBPGAssociations;

	[Header("Rename Settings")]
	public string namePrefix;

	public bool includeLockId;

	public bool includeCount;

	[Header("Bounds Settings")]
	private readonly float boundsPadding;

	private readonly bool logEachAssociation;

	private readonly int selectedAssociationIndex;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private static List<RisingBlockController> FindAllRisingBlocksIncludingInactive()
	{
		return null;
	}

	[Button]
	public void CreateAssociations()
	{
	}

	[Button]
	public void RenamePillGroups()
	{
	}

	public void TestAllRisingBlock()
	{
	}

	public void RebuildAssociationsFromScene()
	{
	}

	public void BuildAssociationsFromScene()
	{
	}

	public void BuildAssociationsFromScene_ThenFill()
	{
	}

	public void AutoFill_ByBounds_ForAllAssociations()
	{
	}

	public void AutoFill_ByBounds_ForSelectedAssociation()
	{
	}

	private void SubscribeToAllRisingBlocks()
	{
	}

	private void UnsubscribeFromAllRisingBlocks()
	{
	}

	private void FillAssociation_ByBounds(int index, List<RisingBlockController> allRbs)
	{
	}
}
