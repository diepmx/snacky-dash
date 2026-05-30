namespace JuicedUp.Features.LoseTutorial
{
	public interface ILoseTutorialRepository
	{
		bool HasShown { get; }

		void MarkShown();
	}
}
