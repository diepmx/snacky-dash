namespace Voodoo.Live
{
	public interface IOperator : IResultProvider<OperatorMountResult>
	{
		string Key { get; }

		string ErrorMessage { get; }

		bool Evaluate(IBlackboard parameters);
	}
}
