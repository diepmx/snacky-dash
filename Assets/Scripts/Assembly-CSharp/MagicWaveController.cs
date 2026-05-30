using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyButtons;
using UnityEngine;

public class MagicWaveController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaveRoutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MagicWaveController _003C_003E4__this;

		private float _003Celapsed_003E5__2;

		private float _003CsoundTimer_003E5__3;

		private float _003CfadeElapsed_003E5__4;

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
		public _003CWaveRoutine_003Ed__22(int _003C_003E1__state)
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

	[Header("Wave Settings")]
	public Material grassMat;

	public Transform waveCenter;

	[Header("Animation Durations")]
	public float waveSpeed;

	public float waveDuration;

	public float fadeOutDuration;

	[Header("Shader Parameters")]
	public Color baseColor;

	public Color waveColor;

	[Range(0f, 5f)]
	public float waveThickness;

	[Range(0f, 2f)]
	public float waveStrength;

	[Range(0f, 20f)]
	public float waveFrequency;

	[Range(0f, 10f)]
	public float waveShaderSpeed;

	[Range(0f, 3f)]
	public float emissionBoost;

	[Header("Sound Settings")]
	public string startSound;

	public float pulseInterval;

	private bool isWaveActive;

	private float radius;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[Button("Apply Defaults")]
	public void ApplyShaderDefaults()
	{
	}

	[Button("Reset Wave")]
	public void ResetWave()
	{
	}

	private void OnCompletingOneChunk()
	{
	}

	[IteratorStateMachine(typeof(_003CWaveRoutine_003Ed__22))]
	private IEnumerator WaveRoutine()
	{
		return null;
	}
}
