using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MiniSoundManager
{
	public class SoundManagerV2 : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass23_0
		{
			public AudioSource source;

			internal bool _003CReturnToPoolAfterPlaying_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass24_0
		{
			public AudioSource source;

			internal bool _003CReturnToPoolAfterPlaying_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CReturnToPoolAfterPlaying_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioSource source;

			public Sound s;

			private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

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
			public _003CReturnToPoolAfterPlaying_003Ed__23(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CReturnToPoolAfterPlaying_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioSource source;

			private _003C_003Ec__DisplayClass24_0 _003C_003E8__1;

			public float defaultPitch;

			public Sound s;

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
			public _003CReturnToPoolAfterPlaying_003Ed__24(int _003C_003E1__state)
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

		public static SoundManagerV2 Instance;

		public Sound[] sounds;

		private readonly float eatPillCooldown;

		private readonly Dictionary<string, float> soundPausePositions;

		private Dictionary<string, Sound> soundDictionary;

		private bool soundIsAlreadyPlaying;

		private float timer_EatPillSound;

		private float timer_DestroyOnePart;

		private void Awake()
		{
		}

		public void Update()
		{
		}

		public void PlaySoundGetPill()
		{
		}

		public void PlaySoundGetPill(int stackedPills)
		{
		}

		public void PlaySoundShootToCrate(int count)
		{
		}

		public void PlaySoundComboCrate(int count)
		{
		}

		public void PlayOneShot(string soundName)
		{
		}

		public void PlayOneShot(string soundName, float pitchOverride)
		{
		}

		public void PauseSound(string soundName)
		{
		}

		public void ResumeSound(string soundName)
		{
		}

		public void StopSound(string soundName)
		{
		}

		private void InitializeSounds()
		{
		}

		private void ConfigureSource(AudioSource source, Sound s)
		{
		}

		private void PlayFromPool(Sound s)
		{
		}

		private void PlayFromPool(Sound s, float pitchOverride)
		{
		}

		[IteratorStateMachine(typeof(_003CReturnToPoolAfterPlaying_003Ed__23))]
		private IEnumerator ReturnToPoolAfterPlaying(Sound s, AudioSource source)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CReturnToPoolAfterPlaying_003Ed__24))]
		private IEnumerator ReturnToPoolAfterPlaying(Sound s, AudioSource source, float defaultPitch)
		{
			return null;
		}
	}
}
