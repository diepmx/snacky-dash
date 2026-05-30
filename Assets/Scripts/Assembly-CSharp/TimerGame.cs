using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JuicedUp.Common.Economy.Public.Data;
using JuicedUp.Core.Bootstrap;
using JuicedUp.Features.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VContainer;

public class TimerGame : MonoBehaviour, IAsyncInitializable
{
	[CompilerGenerated]
	private sealed class _003CPauseCoroutine_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TimerGame _003C_003E4__this;

		public float seconds;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CPauseCoroutine_003Ed__70(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static Action OnTimesUp;

	public bool testMode;

	[Header("Warning FX")]
	public RectTransform timerTextRect;

	public RectTransform warningButtonRect;

	public Image warningButtonImage;

	public Color warningRed;

	[Header("FX Tuning")]
	public float tickPulseScale;

	public float tickPulseHalfDuration;

	public float finalTextScale;

	public float finalButtonScale;

	public float finalPulseDuration;

	[Header("Victory FX")]
	public Color victoryBackGroundColor;

	public float victoryColorTweenDuration;

	public int victoryFlashLoops;

	public Color stoppedColor;

	public float stoppedColorTweenDuration;

	public Image freezeIconImage;

	public Sprite freezeSprite;

	public float freezeFadeDuration;

	public CanvasGroup canvasGroup;

	[Header("Config")]
	public float secondsToComplete;

	[Header("UI")]
	public TextMeshProUGUI timerText;

	[Header("Events")]
	public UnityEvent onTimerEnd;

	private int _warningThreshold;

	private int _urgentThreshold;

	private Color _buttonBaseColor;

	private Vector3 _buttonBaseScale;

	private Tween _buttonFlashTween;

	private Tween _finalButtonColorTween;

	private Tween _finalButtonTween;

	private bool _finalPulseStarted;

	private Tween _finalTextTween;

	private Vector3 _freezeBaseScale;

	private Tween _freezeTween;

	private int _lastCeilSecond;

	private Tween _stoppedColorTween;

	private Vector3 _textBaseScale;

	private Tween _tickTextTween;

	private Color _timerBaseColor;

	private Tween _victoryColorTween;

	private bool isPaused;

	private bool isRunning;

	private float timeRemaining;

	private IGameStateReader _gameStateReader;

	private bool IsTimesUpDefeat => false;

	[Inject]
	public void Construct(IGameStateReader gameStateReader)
	{
	}

	public UniTask InitAsync(CancellationToken cancellationToken)
	{
		return default(UniTask);
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void TimeIsUp()
	{
	}

	public void PauseTimerFor(float seconds)
	{
	}

	public void StartTimer()
	{
	}

	public void StopTimer(TimerStopReason reason = TimerStopReason.PausedOrStopped)
	{
	}

	public void ResetTimer()
	{
	}

	public void AddSeconds(float seconds)
	{
	}

	internal void Triggervictory()
	{
	}

	private void OnTriggeringBooster(BoosterId type)
	{
	}

	private void OnStartingGame()
	{
	}

	private void PlayVictoryStopColor()
	{
	}

	private void ResetVictoryColor()
	{
	}

	private void OnFirstSwipe()
	{
	}

	private void OnLevelBuilt(LevelDataSO data, LevelMeta meta)
	{
	}

	private void EndTimer()
	{
	}

	private void OnSecondTick(int secLeft)
	{
	}

	private void TickPulseText()
	{
	}

	private void FlashButtonOnce()
	{
	}

	private void StartFinalPulseInverted()
	{
	}

	private void StopFinalPulse()
	{
	}

	[IteratorStateMachine(typeof(_003CPauseCoroutine_003Ed__70))]
	private IEnumerator PauseCoroutine(float seconds)
	{
		return null;
	}

	private void ApplyStoppedVisuals()
	{
	}

	private void ResetStoppedVisuals()
	{
	}

	private void UpdateUI()
	{
	}

	private void ApplyStopVisuals(TimerStopReason reason)
	{
	}
}
