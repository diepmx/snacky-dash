using UnityEngine;

public class AndroidTaptic
{
	public static long LightDuration;

	public static long MediumDuration;

	public static long HeavyDuration;

	public static int LightAmplitude;

	public static int MediumAmplitude;

	public static int HeavyAmplitude;

	private static int _sdkVersion;

	private static long[] _successPattern;

	private static int[] _successPatternAmplitude;

	private static long[] _warningPattern;

	private static int[] _warningPatternAmplitude;

	private static long[] _failurePattern;

	private static int[] _failurePatternAmplitude;

	private static AndroidJavaClass UnityPlayer;

	private static AndroidJavaObject CurrentActivity;

	private static AndroidJavaObject AndroidVibrator;

	private static AndroidJavaClass VibrationEffectClass;

	private static AndroidJavaObject VibrationEffect;

	private static int DefaultAmplitude;

	private void Vib()
	{
	}

	public static void Vibrate()
	{
	}

	public static void Haptic(HapticTypes type)
	{
	}

	public static void AndroidVibrate(long milliseconds)
	{
	}

	public static void AndroidVibrate(long milliseconds, int amplitude)
	{
	}

	public static void AndroidVibrate(long[] pattern, int repeat)
	{
	}

	public static void AndroidVibrate(long[] pattern, int[] amplitudes, int repeat)
	{
	}

	public static void AndroidCancelVibrations()
	{
	}

	private static void VibrationEffectClassInitialization()
	{
	}

	public static int AndroidSDKVersion()
	{
		return 0;
	}
}
