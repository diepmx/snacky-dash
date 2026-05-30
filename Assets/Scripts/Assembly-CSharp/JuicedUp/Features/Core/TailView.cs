using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class TailView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBumpTheTail_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TailView _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CBumpTheTail_003Ed__29(int _003C_003E1__state)
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

		[Header("Tail Spacing")]
		[FormerlySerializedAs("spacingFactor")]
		[SerializeField]
		private float _spacingFactor;

		[SerializeField]
		[FormerlySerializedAs("defaultSpacing")]
		private float _defaultSpacing;

		[SerializeField]
		[FormerlySerializedAs("compressedSpacing")]
		private float _compressedSpacing;

		[FormerlySerializedAs("durationBump")]
		[SerializeField]
		private float _durationBump;

		[FormerlySerializedAs("particleTailBump")]
		[SerializeField]
		private GameObject _particleTailBump;

		private List<TailSegment> _segments;

		private const int BaseSortingOrder = 1000;

		private Tweener _spacingTween;

		private int _tunnelDepth;

		public float SpacingFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DefaultSpacing => 0f;

		public float CompressedSpacing => 0f;

		public float DurationBump => 0f;

		public GameObject ParticleTailBump => null;

		public static event Action<Dictionary<PillKind, int>> OnUpdatingTailColors
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Init(List<TailSegment> segments)
		{
		}

		public void TweenSpacingTo(float target, float duration = 0.2f)
		{
		}

		public void PushTunnelCompression(float compressedSpacing, float tween = 0.2f)
		{
		}

		public void PopTunnelCompression(float tween = 0.2f)
		{
		}

		public void AssignMaterial(GameObject tailSegment, PillKind pillKind, PillType pillType)
		{
		}

		public void ReapplySortingOrders()
		{
		}

		[IteratorStateMachine(typeof(_003CBumpTheTail_003Ed__29))]
		public IEnumerator BumpTheTail()
		{
			return null;
		}

		private Dictionary<PillKind, int> GetTailColorCounts()
		{
			return null;
		}

		public void UpdateTailColor()
		{
		}

		public void RefreshPillUI()
		{
		}
	}
}
