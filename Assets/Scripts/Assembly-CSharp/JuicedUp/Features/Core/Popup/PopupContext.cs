namespace JuicedUp.Features.Core.Popup
{
	public class PopupContext
	{
		public int CurrentLevel { get; set; }

		public int SessionIndex { get; set; }

		public int LivesCount { get; set; }

		public float TimeSinceLevelEnd { get; set; }

		public PopupHistory History { get; set; }
	}
}
