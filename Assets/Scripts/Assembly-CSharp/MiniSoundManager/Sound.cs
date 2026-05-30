using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniSoundManager
{
	[Serializable]
	public class Sound
	{
		public string name;

		public SoundType soundType;

		public AudioClip clip;

		[Range(0f, 1f)]
		public float volume;

		[Range(0.1f, 3f)]
		public float pitch;

		public bool usePool;

		public int poolSize;

		public bool looping;

		[HideInInspector]
		public AudioSource source;

		public Queue<AudioSource> pool;
	}
}
