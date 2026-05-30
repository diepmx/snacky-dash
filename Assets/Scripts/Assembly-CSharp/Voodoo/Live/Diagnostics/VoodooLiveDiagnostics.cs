using System.Collections.Generic;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Diagnostics
{
	public class VoodooLiveDiagnostics
	{
		private readonly List<DiagnosticEntry> _diagnosticEntries;

		public DiagnosticReport GenerateReport()
		{
			return null;
		}

		private void CollectFeatureDiagnostics(List<DiagnosticEntry> entries)
		{
		}

		private void CollectFeatureValidation(List<DiagnosticEntry> entries, IFeature feature)
		{
		}

		private void CollectOperatorDiagnostics(List<DiagnosticEntry> entries, Conditionnal conditionnal, string context)
		{
		}

		private void CollectCampaignDiagnostics(List<DiagnosticEntry> entries)
		{
		}

		private void CollectInventoryDiagnostics(List<DiagnosticEntry> entries)
		{
		}

		private void CollectConfigDiagnostics(List<DiagnosticEntry> entries)
		{
		}

		private void CollectTransactionDiagnostics(List<DiagnosticEntry> entries)
		{
		}

		public IReadOnlyList<DiagnosticEntry> GetDiagnosticEntries()
		{
			return null;
		}

		public void ReportDiagnostic(DiagnosticCode code, string message, string context = null)
		{
		}

		public void Clear()
		{
		}
	}
}
