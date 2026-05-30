using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyButtons;
using JuicedUp.Features.Core;
using UnityEngine;

public class PillCounter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSequenceChunkOver_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PillCounter _003C_003E4__this;

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
		public _003CSequenceChunkOver_003Ed__25(int _003C_003E1__state)
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

	public static Action OnCompletingOneChunk;

	public static Action OnCompletingOneChunk_ForVisual;

	public static Action<int> OnUpdatedPillsOnChunk;

	[Header("Booleans")]
	public int pillsCount;

	public LayerMask targetLayer;

	public List<Collider2D> allCollidersFound;

	public bool isCompleted;

	[SerializeField]
	private float gizmoSize;

	[SerializeField]
	private bool showPillGizmos;

	public Dictionary<Vector3Int, bool> allPillsInChunk;

	private readonly bool isResetting;

	private BoxCollider2D box2D;

	private Grid _grid;

	private PillManager _pillManager;

	public void Init(PillManager pillManager, Grid grid)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void SubscribeToPillManager()
	{
	}

	private void UnsubscribeFromPillManager()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	public bool IsTheChunkOver()
	{
		return false;
	}

	[Button("Count Pills")]
	public int CountAllPills()
	{
		return 0;
	}

	public void SetPillsChunkId()
	{
	}

	private void OnPillActiveStateChangedListener(Vector3Int tile, bool isActive)
	{
	}

	private void OnTurnOverListener()
	{
	}

	[IteratorStateMachine(typeof(_003CSequenceChunkOver_003Ed__25))]
	private IEnumerator SequenceChunkOver()
	{
		return null;
	}

	private void UpdateCurrentPillCount()
	{
	}

	private void OnEatingPillListener(Vector3Int tile)
	{
	}

	private void OnSpawningPillListener(Vector3Int tile)
	{
	}
}
