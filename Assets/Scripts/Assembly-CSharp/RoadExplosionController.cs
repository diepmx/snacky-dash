using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class RoadExplosionController : MonoBehaviour
{
	private readonly struct RoadPiece
	{
		public readonly Vector2Int Cell;

		public readonly GameObject Go;

		public RoadPiece(Vector2Int cell, GameObject go)
		{
			Cell = default(Vector2Int);
			Go = null;
		}
	}

	private class Group
	{
		public readonly List<RoadPiece> Pieces;

		public readonly HashSet<GameObject> PieceSet;

		public int EndsDestroyed;

		public Action OnExploded;

		public bool Triggered;
	}

	[CompilerGenerated]
	private sealed class _003CExplodeGroup_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Group group;

		public RoadExplosionController _003C_003E4__this;

		private int _003Cleft_003E5__2;

		private int _003Cright_003E5__3;

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
		public _003CExplodeGroup_003Ed__12(int _003C_003E1__state)
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

	private const string RoadStepSound = "RoadStepExplode";

	private const float RoadStepVfxLifetime = 2f;

	private const float RoadStepDelay = 0.1425f;

	private readonly WaitForSeconds _stepWait;

	private readonly Comparison<RoadPiece> _sortByX;

	private readonly Comparison<RoadPiece> _sortByY;

	private readonly Vector2 _roadStepPitchRange;

	private readonly Dictionary<int, Group> _groups;

	private ParticleSystem _roadStepParticlePrefab;

	[Inject]
	public void Construct(ParticleSystem roadExplosionParticle)
	{
	}

	public void AddRoadPiece(int groupId, Vector2Int cell, GameObject go)
	{
	}

	public void NotifyEndDestroyed(int groupId, Action onExploded)
	{
	}

	[IteratorStateMachine(typeof(_003CExplodeGroup_003Ed__12))]
	private IEnumerator ExplodeGroup(Group group)
	{
		return null;
	}

	private void ExplodePiece(GameObject piece)
	{
	}
}
