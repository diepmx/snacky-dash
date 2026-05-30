using System.Collections.Generic;
using JuicedUp.Features.Core;
using UnityEngine;

public class Crate : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Transform _fruitParent;

	[SerializeField]
	private List<CrateDestinationPoints> _destinationPoints;

	[SerializeField]
	private List<GameObject> _lids;

	[SerializeField]
	private List<SpriteRenderer> _iconFruit;

	[Header("Particles")]
	[SerializeField]
	private ParticleSystem _confettiPS;

	private PillKind _pillKindCrate;

	private bool _useIconsWithOutline;

	public ParticleSystem ConfettiPS => null;

	public int LidsCount => 0;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}

	public void SyncSlotsFromFilledCount(int filledCount)
	{
	}

	public void ResetSlots()
	{
	}

	public void ApplyColor(PillKind pillKind, bool useIconsWithOutline)
	{
	}

	public bool TryGetNextSlot(out CrateSlot slot)
	{
		slot = default(CrateSlot);
		return false;
	}

	private void CacheIdleSlotPositions()
	{
	}

	private void CloseLid(int lidIndex)
	{
	}

	private void OpenAllLids()
	{
	}
}
