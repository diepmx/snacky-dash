namespace Voodoo.Live.Diagnostics
{
	public readonly struct DiagnosticEntry
	{
		public DiagnosticCode Code { get; }

		public string Message { get; }

		public string Context { get; }

		public DiagnosticEntry(DiagnosticCode code, string message, string context = null)
		{
			Code = default(DiagnosticCode);
			Message = null;
			Context = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
