namespace Voodoo.Live
{
	public interface IResultProvider
	{
		Result Validation { get; }

		void Validate();
	}
	public interface IResultProvider<T> where T : Result
	{
		T Validation { get; }

		void Validate();
	}
}
