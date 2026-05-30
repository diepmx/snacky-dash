using System.Collections.Generic;

public class AHIncidentData
{
	public string UnitId { get; }

	public AHAdSdk AdNetwork { get; }

	public string CreativeId { get; }

	public AHAdFormat AdFormat { get; }

	public bool ShouldLoadNewAd { get; }

	public List<string> BlockReasons { get; }

	public List<string> ReportReasons { get; }

	public string UserDefinedApplication { get; }

	public string UserDefinedDomain { get; }

	public AHAdAnalyzedResult AnalyzeResult { get; }

	public AHIncidentData(string unitId = "", AHAdSdk adNetwork = AHAdSdk.None, string creativeId = "", AHAdFormat adFormat = AHAdFormat.Banner, bool shouldLoadNewAd = false, List<string> blockReasons = null, List<string> reportReasons = null, string userDefinedApplication = "", string userDefinedDomain = "", AHAdAnalyzedResult analyzeResult = AHAdAnalyzedResult.NoResultAnalyzed)
	{
	}
}
