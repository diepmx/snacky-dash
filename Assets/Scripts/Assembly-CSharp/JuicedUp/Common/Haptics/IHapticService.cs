namespace JuicedUp.Common.Haptics
{
	public interface IHapticService
	{
		void Selection();

		void LightImpact();

		void MediumImpact();

		void HeavyImpact();

		void Success();

		void ButtonTap();

		void ProgressTick();

		void ComboReward();
	}
}
