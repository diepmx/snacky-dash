using JuicedUp.Common.Economy.Public.Data;

namespace JuicedUp.Features.WeeklyMissions.Public
{
	public class MissionData
	{
		private const string MissionAmountSaveKey = "Mission_{0}_Current_Amount";

		private const string MissionStatusSaveKey = "Mission_{0}_{1}_Current_Status";

		public MissionGoalType Type;

		public IBundle Bundle;

		public string Description;

		public int Amount;

		public int GetCurrentAmount()
		{
			return 0;
		}

		public void AddAmount(int amount)
		{
		}

		public MissionStatus GetStatus()
		{
			return default(MissionStatus);
		}

		public void MarkAsClaimed()
		{
		}

		public void MarkAsCompleted()
		{
		}

		public void ResetAmount()
		{
		}

		public void ResetStatus()
		{
		}

		public void ResetAllSaveData()
		{
		}
	}
}
