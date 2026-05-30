using System.Collections.Generic;
using PolyAndCode.UI;
using UnityEngine;

public class RecyclableScrollerDemo : MonoBehaviour, IRecyclableScrollRectDataSource
{
	[SerializeField]
	private RecyclableScrollRect _recyclableScrollRect;

	[SerializeField]
	private int _dataLength;

	private List<ContactInfo> _contactList;

	private void Awake()
	{
	}

	private void InitData()
	{
	}

	public int GetItemsCount()
	{
		return 0;
	}

	public void SetCell(ICell cell, int index)
	{
	}

	public void OnAllCellsInstantiated(List<ICell> cells)
	{
	}

	public void Clear()
	{
	}
}
