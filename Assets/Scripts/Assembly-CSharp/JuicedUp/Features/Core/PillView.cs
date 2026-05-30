using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class PillView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateJumpLocal_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform t;

			public Vector3 localStart;

			public float duration;

			public Vector3 localEnd;

			public float jumpHeight;

			private float _003CtimeElapsed_003E5__2;

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
			public _003CAnimateJumpLocal_003Ed__35(int _003C_003E1__state)
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
		private sealed class _003CAnimateJumpToPosition_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public Vector3 startPoint;

			public Vector3 endPoint;

			public float jumpHeight;

			public Transform moveTransform;

			public Transform rootTransform;

			public GameObject pill;

			public Action<int> onComplete;

			public int idChunk;

			public PillView _003C_003E4__this;

			private float _003CtimeElapsed_003E5__2;

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
			public _003CAnimateJumpToPosition_003Ed__36(int _003C_003E1__state)
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
		private sealed class _003CAnimatePushDownCoroutine_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform pillTransform;

			public Vector3 localPush;

			public PillView _003C_003E4__this;

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
			public _003CAnimatePushDownCoroutine_003Ed__37(int _003C_003E1__state)
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
		private sealed class _003CWaitForTailClear_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PillView _003C_003E4__this;

			public TailManager tailManager;

			public Vector3 worldEnd;

			private float _003CclearTime_003E5__2;

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
			public _003CWaitForTailClear_003Ed__33(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		private Transform _visualParent;

		[SerializeField]
		private Transform _fruitsParent;

		[SerializeField]
		private List<PillColorShape> _allShapes;

		[SerializeField]
		private Transform _secretCollectibleParent;

		[Header("Respawn Jump Settings")]
		[SerializeField]
		private float _respawnSideDistance;

		[SerializeField]
		private float _respawnSpawnZ;

		[SerializeField]
		private float _respawnJumpHeight;

		[SerializeField]
		private float _respawnJumpDuration;

		[SerializeField]
		private float _respawnPushDuration;

		[Header("Respawn Safety Check")]
		[SerializeField]
		private float _respawnCheckRadius;

		[SerializeField]
		private float _respawnCheckInterval;

		[SerializeField]
		private float _respawnMinClearTime;

		[Header("Respawn Offset")]
		[SerializeField]
		private float _respawnOffsetXYRadius;

		private Vector3 _baseLocalPos;

		private bool _baseLocalPosRecorded;

		public float RespawnJumpHeight => 0f;

		public float RespawnJumpDuration => 0f;

		public Transform FruitsParent => null;

		public List<PillColorShape> AllShapes => null;

		public Transform SecretCollectibleParent => null;

		public Transform VisualParent => null;

		public void RecordBaseLocalPos(Transform pillTransform)
		{
		}

		public void EnsureBaseLocalPos(Transform pillTransform)
		{
		}

		public Vector3 GetBaseLocalPos()
		{
			return default(Vector3);
		}

		public void PlayShakeScale(Transform target)
		{
		}

		public Vector3 GetSideSpawnLocalPosition(Vector3 localEnd, TileType tileType)
		{
			return default(Vector3);
		}

		public Coroutine AnimatePushDown(Transform pillTransform, Vector3 localPush)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitForTailClear_003Ed__33))]
		public IEnumerator WaitForTailClear(TailManager tailManager, Vector3 worldEnd)
		{
			return null;
		}

		public bool IsTailOnSpot(TailManager tailManager, Vector3 worldEnd)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CAnimateJumpLocal_003Ed__35))]
		public IEnumerator AnimateJumpLocal(Transform t, Vector3 localStart, Vector3 localEnd, float jumpHeight, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateJumpToPosition_003Ed__36))]
		public IEnumerator AnimateJumpToPosition(float duration, Transform moveTransform, Vector3 startPoint, Vector3 endPoint, float jumpHeight, Transform rootTransform, GameObject pill, Action<int> onComplete, int idChunk)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimatePushDownCoroutine_003Ed__37))]
		private IEnumerator AnimatePushDownCoroutine(Transform pillTransform, Vector3 localPush)
		{
			return null;
		}
	}
}
