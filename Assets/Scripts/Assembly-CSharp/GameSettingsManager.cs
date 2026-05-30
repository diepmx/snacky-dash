using JuicedUp.Features.Core;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
	public static GameSettingsManager Instance;

	private const string MusicLobbyKey = "Music_Lobby";

	private const string MusicCoreKey = "Music_Core";

	public bool MusicEnabled { get; private set; }

	public bool SoundEnabled { get; private set; }

	public bool HapticsEnabled { get; private set; }

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameStateChanged(GameState state, DefeatType defeatType)
	{
	}

	public void ToggleMusic(bool isMusicEnabled)
	{
	}

	private void ApplyActiveMusicTracks()
	{
	}

	public void ToggleSounds(bool isSoundEnabled)
	{
	}

	public void ToggleHaptics(bool isHapticsEnabled)
	{
	}
}
