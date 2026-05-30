using System;
using UnityEngine;

public class MoneyData : MonoBehaviour
{
	public static MoneyData instance;

	public static Action<int> OnAddingMoney;

	public int currentMoney;

	private void Awake()
	{
	}

	public void AddMoney(int amount)
	{
	}
}
