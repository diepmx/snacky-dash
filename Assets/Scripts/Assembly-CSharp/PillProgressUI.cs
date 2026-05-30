using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public class PillProgressUI : MonoBehaviour
{
	public List<PillColorUI> pillColorUI;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnUpdatingTail(Dictionary<PillKind, int> pillKinds)
	{
	}
}
