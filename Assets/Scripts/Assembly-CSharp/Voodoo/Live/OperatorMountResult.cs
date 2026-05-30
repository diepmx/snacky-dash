using Voodoo.Live.Diagnostics;

namespace Voodoo.Live
{
	public class OperatorMountResult : Result
	{
		public string[] parameters;

		public OperatorMountResult(string[] parameters)
		{
		}

		public void Fail(DiagnosticCode code, string errorMessage = null, string context = null)
		{
		}
	}
}
