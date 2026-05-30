using System.Collections.Generic;

public class AHTimeLimitConfig
{
	public AHAdFormat AdFormat { get; }

	public Dictionary<int, AHAdSdk[]> TimeLimitInSeconds { get; set; }

	public AHTimeLimitConfig(AHAdFormat adFormat)
	{
	}

	public AHTimeLimitConfig AppendConfig(int timeout, AHAdSdk[] timeLimit)
	{
		return null;
	}
}
