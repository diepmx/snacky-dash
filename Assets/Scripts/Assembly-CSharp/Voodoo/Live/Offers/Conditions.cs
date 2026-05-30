using System;
using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public class Conditions
	{
		public int capping;

		public int frequency;

		public int cooldownAfterPurchaseInHours;

		public int campaignCooldownInHours;

		public string campaignCooldownTrigger;

		public DateTime startDate;

		public DateTime endDate;

		public ActiveTimeConfig activeTime;

		public List<DayOfWeek> day;

		public string[] tags;

		public int purchaseLimit;

		public void ToConditions(Conditionnal conditionnal, bool applyNonConsumable = true)
		{
		}

		private void ResetDisplayLimit(Conditionnal conditionnal)
		{
		}

		public void AddTimeOperator(Conditionnal conditionnal)
		{
		}

		public RecurrenceType GetRecurrenceType()
		{
			return default(RecurrenceType);
		}

		public void AddNonConsumableOperator(Conditionnal conditionnal)
		{
		}

		private void CollectNonConsumableItemsFromProducts(List<Product> products, List<string> itemsNames)
		{
		}

		private void CollectNonConsumableItemsFromProduct(Product product, List<string> itemsNames)
		{
		}

		public string GetId(Conditionnal conditionnal)
		{
			return null;
		}

		public string GetEntityType(Conditionnal conditionnal)
		{
			return null;
		}
	}
}
