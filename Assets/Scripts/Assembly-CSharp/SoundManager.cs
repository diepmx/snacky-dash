using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CResetSoundIsPlaying_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SoundManager _003C_003E4__this;

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
		public _003CResetSoundIsPlaying_003Ed__41(int _003C_003E1__state)
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

	public static SoundManager instance;

	public AudioClip sound_shootToCrate;

	public AudioClip sound_hitTail;

	public AudioClip sound_GetPill;

	public AudioClip sound_GetPill2;

	public AudioClip sound_GetPill3;

	public AudioClip sound_victoryChunk;

	public AudioClip sound_Swipe;

	public AudioClip sound_SpawnPillFromSpawner;

	public AudioClip sound_BumpDefeat;

	public AudioClip sound_openLock;

	public AudioClip sound_ExplosionTailPortal;

	public AudioClip sound_PopPlot;

	public AudioClip sound_Coins;

	public AudioSource audioSourceDefault;

	public AudioSource audioSource2;

	public AudioSource audioSource3;

	public AudioSource audioSource_blocksBoss;

	public AudioSource audioSource_Fire;

	public AudioSource audioSource_DestructionSegment;

	private bool soundIsAlreadyPlaying;

	private float timer_EatPillSound;

	private float timer_DestroyOnePart;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	public void Update()
	{
	}

	public void PlaySoundGetPill()
	{
	}

	public void PlaySound_HitTail()
	{
	}

	public void PlaySound_PopPlot()
	{
	}

	public void PlaySound_coins()
	{
	}

	public void PlaySound_BumpDefeat()
	{
	}

	public void PlaySound_SpawnPillFromSpawner()
	{
	}

	public void PlaySound_OpenLock()
	{
	}

	public void PlaySoundSwipe()
	{
	}

	public void PlaySoundLoseOnPill()
	{
	}

	public void PlaySoundDefault(AudioClip sound, float pitch)
	{
	}

	public void PlaySoundSecondary(AudioClip sound)
	{
	}

	public void PlaySoundThird(AudioClip sound)
	{
	}

	public void OnTakingPill(int stackedPucks)
	{
	}

	internal void PlayExplosionTailPortal()
	{
	}

	internal void PlaySoundVictoryChunck()
	{
	}

	[IteratorStateMachine(typeof(_003CResetSoundIsPlaying_003Ed__41))]
	private IEnumerator ResetSoundIsPlaying()
	{
		return null;
	}
}
