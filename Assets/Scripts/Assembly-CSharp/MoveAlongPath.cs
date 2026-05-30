using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JuicedUp.Features.Core;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFollowPath_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MoveAlongPath _003C_003E4__this;

		public List<Vector3> allPositionsPath;

		private int _003CcurrentPointIndex_003E5__2;

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
		public _003CFollowPath_003Ed__8(int _003C_003E1__state)
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

	public float speed;

	public TrailRenderer trailRenderer;

	public Transform player;

	private TailManager tailManagerScript;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GoAlongPath(List<Vector3> path)
	{
	}

	public void ResetTrail()
	{
	}

	[IteratorStateMachine(typeof(_003CFollowPath_003Ed__8))]
	private IEnumerator FollowPath(List<Vector3> allPositionsPath)
	{
		return null;
	}
}
