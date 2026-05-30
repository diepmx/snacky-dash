using System;

[Serializable]
public class LivesState
{
	public int maxLives;

	public int regenSeconds;

	public long nextLifeAtUtc;

	public long trustedBaseUtc;

	public long trustedBaseDeviceUtc;

	public long lastTrustedNowUtc;

	public bool tamperFlag;

	public int safeModeSecondsRemaining;

	public bool isLevelSessionActive;

	public bool hasCompletedFirstRegen;

	public bool hasUsedFreeRefill;

	public int defaults_maxLives;

	public int defaults_regenSeconds;
}
