using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using JuicedUp.Features.Boosters.Config;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class CrateView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CJumpToPosition_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform pill;

			public CrateSlot slot;

			public CrateView _003C_003E4__this;

			public bool isBoomerang;

			public GameObject preAttachedVfx;

			public float jumpHeight;

			private Vector3 _003CworldStart_003E5__2;

			private Vector3 _003CstartScale_003E5__3;

			private Vector3 _003CendScale_003E5__4;

			private Quaternion _003CstartRot_003E5__5;

			private Quaternion _003CendRot_003E5__6;

			private float _003Celapsed_003E5__7;

			private float _003CtimeToCrate_003E5__8;

			private GameObject _003CvfxInstance_003E5__9;

			private float _003CmaxScaleMultiplier_003E5__10;

			private Ease _003CpositionEase_003E5__11;

			private Ease _003CscaleEase_003E5__12;

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
			public _003CJumpToPosition_003Ed__54(int _003C_003E1__state)
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
		private sealed class _003CRiseToSky_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform pill;

			public float duration;

			public Vector3 endPos;

			public Vector3 startPos;

			public Ease ease;

			private float _003Celapsed_003E5__2;

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
			public _003CRiseToSky_003Ed__59(int _003C_003E1__state)
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

		[Header("Combo UI")]
		[SerializeField]
		private ComboView _comboView;

		[Header("Column Side UI")]
		[SerializeField]
		[FormerlySerializedAs("columnUiPrefab")]
		private CrateColumnSideUI _columnUiPrefab;

		[SerializeField]
		[FormerlySerializedAs("columnUiParent")]
		private RectTransform _columnUiParent;

		[SerializeField]
		[FormerlySerializedAs("canvasRect")]
		private RectTransform _canvasRect;

		[SerializeField]
		[FormerlySerializedAs("worldCam")]
		private Camera _worldCam;

		[Header("Column Side UI Placement")]
		[SerializeField]
		[FormerlySerializedAs("uiOffset")]
		private Vector2 _uiOffset;

		[SerializeField]
		[FormerlySerializedAs("clampToCanvas")]
		private bool _clampToCanvas;

		[SerializeField]
		[FormerlySerializedAs("canvasPadding")]
		private Vector2 _canvasPadding;

		[Header("Column Side UI Visibility")]
		[SerializeField]
		[FormerlySerializedAs("enableNextCrateUI")]
		private bool _enableNextCrateUI;

		[SerializeField]
		[FormerlySerializedAs("nextCrateUiMinLevel")]
		private int _nextCrateUIMinimumLevel;

		[Header("Delivery Button")]
		[SerializeField]
		private GameObject _deliveryButtonRoot;

		private readonly List<CrateColumnSideUI> _columnUis;

		private readonly List<NextCrateSign> _nextCrateSigns;

		private CrateVisualConfig _config;

		private BoosterConfigSO _boosterConfig;

		private GameObject _boomerangFlightVfxPrefab;

		private Transform _boomerangFlightVfxParent;

		private ObjectPool<GameObject> _boomerangFlightVfxPool;

		private List<CrateColumn> _columns;

		private Transform _cratesParent;

		private int _currentLevel;

		private List<CrateDeliverPoint> _deliveryPoints;

		public Vector3 LastCompletedCratePos { get; set; }

		public CrateVisualConfig ActiveConfig => null;

		public void SetConfig(CrateVisualConfig config)
		{
		}

		public void SetBoosterConfig(BoosterConfigSO boosterConfig)
		{
		}

		public void SetBoomerangFlightVfx(GameObject prefab, Transform parent)
		{
		}

		public void Init(List<CrateColumn> columns)
		{
		}

		private void LateUpdate()
		{
		}

		private static Vector2 ClampToCanvas(Vector2 pos, RectTransform uiRect, RectTransform canvasRect, Vector2 padding)
		{
			return default(Vector2);
		}

		public YieldInstruction WaitForCrateComplete()
		{
			return null;
		}

		public YieldInstruction WaitForMoveToDeliver()
		{
			return null;
		}

		public YieldInstruction WaitForTimeToCrate(bool isBoomerang)
		{
			return null;
		}

		public GameObject InstantiateCrate(int requiredCount)
		{
			return null;
		}

		public void SetDeliveryButtonVisible(bool visible)
		{
		}

		public void OnLevelBuilt(List<CrateDeliverPoint> deliveryPoints, int currentLevel)
		{
		}

		public void UpdateColumnUIs()
		{
		}

		public bool CanShowNextCrateUI()
		{
			return false;
		}

		public void ResetComboVisuals()
		{
		}

		public void ShowComboTotal(int total)
		{
		}

		public void OnPillDeliveredToCrate(int pillsDeliveredThisSession)
		{
		}

		public void SetDeliveryPointHighlights(bool[] canDeliverPerColumn)
		{
		}

		public void ActivateDeliveryPointArrows(List<CrateDeliverPoint> deliveryPoints)
		{
		}

		public void SetCrateVisualState(CrateData crate, bool isActive)
		{
		}

		public void PositionCrate(CrateData crate, Vector3 pos, float scale, bool atStart, float moveToDeliverCrate)
		{
		}

		public void ApplyCrateVisuals(Crate crateComp, PillKind kind)
		{
		}

		public List<LaneWaypoint> BuildSpawnToActiveRoute(PositionCrates lane)
		{
			return null;
		}

		public List<LaneWaypoint> BuildActiveToExitRoute(PositionCrates lane)
		{
			return null;
		}

		public Tween MoveSpawnToActive(Transform t, PositionCrates lane, bool instant)
		{
			return null;
		}

		public Tween MoveActiveToExit(Transform t, PositionCrates lane, bool instant)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CJumpToPosition_003Ed__54))]
		public IEnumerator JumpToPosition(Transform pill, CrateSlot slot, float jumpHeight, bool isBoomerang, GameObject preAttachedVfx)
		{
			return null;
		}

		public GameObject RentBoomerangFlightVfx(Transform pill)
		{
			return null;
		}

		public void ReturnBoomerangFlightVfx(GameObject instance)
		{
		}

		private void EnsureBoomerangFlightVfxPool()
		{
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CRiseToSky_003Ed__59))]
		public IEnumerator RiseToSky(Transform pill, Vector3 startPos, Vector3 endPos, float duration, Ease ease)
		{
			return null;
		}

		public void ShowComboUI(int chainCount, int coinsThisStep)
		{
		}

		public void ShowComboFinalUI(int chainCount, int coinsThisStep, int totalCoins)
		{
		}

		private Tween PlayRoute(Transform t, IReadOnlyList<LaneWaypoint> nodes, float totalDuration, float delay, bool instant, bool timeByDistance = true, Ease ease = Ease.Linear)
		{
			return null;
		}

		public void InitNextCrateSigns()
		{
		}

		private void ClearNextCrateSigns()
		{
		}

		public void UpdateNextCrateSign(int columnIndex, PillKind? nextKind)
		{
		}

		private void SetupColumnUIs()
		{
		}

		private List<CratePreviewItem> GetPreviewItems(CrateColumn column, int maximumCount)
		{
			return null;
		}

		private void SetNextCrateUIVisible(bool visible)
		{
		}

		private bool IsLeftColumn(int columnIndex)
		{
			return false;
		}
	}
}
