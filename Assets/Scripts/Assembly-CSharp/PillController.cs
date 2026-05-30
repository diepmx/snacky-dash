using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JuicedUp.Features.Core;
using JuicedUp.Features.Core.SecretCollectible;
using UnityEngine;

public class PillController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRenewPill_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PillController _003C_003E4__this;

		private Vector3 _003ClocalEnd_003E5__2;

		private Vector3 _003CworldEnd_003E5__3;

		private Vector3 _003ClocalPush_003E5__4;

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
		public _003CRenewPill_003Ed__44(int _003C_003E1__state)
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

	public Action<int> OnRenewPill;

	[Header("Settings")]
	[SerializeField]
	private int _idChunk;

	[SerializeField]
	private PillKind _pillKind;

	[SerializeField]
	private PillType _pillType;

	[SerializeField]
	private TileType _tileType;

	[SerializeField]
	private bool _isPillActive;

	[SerializeField]
	private float _offsetValueXY;

	[SerializeField]
	private float _offsetValueZLow;

	[SerializeField]
	private float _offsetValueZHigh;

	[SerializeField]
	private float _offsetMaxVariation;

	[SerializeField]
	private float _randomRotationZ;

	[SerializeField]
	private float _tailWaitPosZ;

	[SerializeField]
	private bool _useRespawnJump;

	[Header("View")]
	[SerializeField]
	private PillView _view;

	[SerializeField]
	private SecretCollectibleController _secretCollectiblePrefab;

	private SecretCollectibleController _activeSecretController;

	private TailManager _tailManager;

	private readonly Dictionary<PillKind, PillColorShape> _pillKindShape;

	public int IdChunk => 0;

	public PillKind PillKind => default(PillKind);

	public PillType PillType => default(PillType);

	public bool IsPillActive => false;

	public GameObject PillVisual => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Init(TailManager tailManager)
	{
	}

	public void SetTileType(TileType tileType)
	{
	}

	public void SetPillKind(PillKind kindOfPill)
	{
	}

	public void SetType(PillType pillType)
	{
	}

	public void SetPillActive(bool active)
	{
	}

	public void NotifyPillSpawnerIfAny()
	{
	}

	public void StartCoroutineRenew()
	{
	}

	public void ExplodeSecretCollectible()
	{
	}

	private void ShowSecretCollectible()
	{
	}

	private void ClearSecretCollectible()
	{
	}

	private void ShowFruit()
	{
	}

	private void HideFruit()
	{
	}

	private void SetShape(PillKind kindOfPill)
	{
	}

	[IteratorStateMachine(typeof(_003CRenewPill_003Ed__44))]
	private IEnumerator RenewPill()
	{
		return null;
	}

	private void BuildShapeDictIfNeeded()
	{
	}
}
