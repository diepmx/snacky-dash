using Voodoo.Live.Diagnostics;

namespace Voodoo.Live
{
	public class Result
	{
		public string ErrorMessage;

		public static Result Success => null;

		public DiagnosticCode Code { get; protected set; }

		public string Context { get; protected set; }

		public bool IsSuccess => false;

		public bool IsFailure => false;

		public static Result Failure()
		{
			return null;
		}

		public static Result Failure(DiagnosticCode code, string errorMessage, string context = null)
		{
			return null;
		}

		public DiagnosticEntry ToDiagnosticEntry()
		{
			return default(DiagnosticEntry);
		}

		public Result WithPrefix(string prefix)
		{
			return null;
		}

		public Result WithContext(string context)
		{
			return null;
		}

		public Result WithCode(DiagnosticCode code)
		{
			return null;
		}
	}
}
