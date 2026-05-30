namespace JuicedUp.Features.Core
{
	public interface IComboTutorialRepository
	{
		bool HasShown { get; }

		void MarkShown();
	}
}
