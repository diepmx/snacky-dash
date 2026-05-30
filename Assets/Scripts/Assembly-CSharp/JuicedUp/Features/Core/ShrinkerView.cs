using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace JuicedUp.Features.Core
{
	public class ShrinkerView : MonoBehaviour
	{
		[Header("Shrink Settings")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float _shrinkScale;

		[SerializeField]
		private float _shrinkDuration;

		[SerializeField]
		private float _regrowDuration;

		[Header("Stay Shrink Settings")]
		[SerializeField]
		private bool _stayShrinkedByMoves;

		[SerializeField]
		private float _stayShrinkedDuration;

		[SerializeField]
		private int _stayShrinkedMoves;

		[SerializeField]
		private bool _autoRegrow;

		[SerializeField]
		private bool _regrowOnlyWhenMoving;

		[Header("Duration Scaling by Tail Length")]
		[SerializeField]
		private int _referenceTailLength;

		[SerializeField]
		private float _minDurationMultiplier;

		[SerializeField]
		private float _maxDurationMultiplier;

		[FormerlySerializedAs("debugPanel")]
		[Header("Debug UI")]
		[SerializeField]
		private GameObject _debugPanel;

		[FormerlySerializedAs("debugEnabled")]
		[SerializeField]
		private bool _debugEnabled;

		[FormerlySerializedAs("debugTurnsLeftText")]
		[SerializeField]
		private TextMeshProUGUI _debugTurnsLeftText;

		[FormerlySerializedAs("debugTimeShrinkText")]
		[SerializeField]
		private TextMeshProUGUI _debugTimeShrinkText;

		[FormerlySerializedAs("debugTimeUnshrinkText")]
		[SerializeField]
		private TextMeshProUGUI _debugTimeUnshrinkText;

		[FormerlySerializedAs("debugNumberOfPartsText")]
		[SerializeField]
		private TextMeshProUGUI _debugNumberOfPartsText;

		[FormerlySerializedAs("debugFactorText")]
		[SerializeField]
		private TextMeshProUGUI _debugFactorText;

		[FormerlySerializedAs("debugExpectedUnshrinkText")]
		[SerializeField]
		private TextMeshProUGUI _debugExpectedUnshrinkText;

		private TailManager _tailManager;

		public float ShrinkScale => 0f;

		public float ShrinkDuration => 0f;

		public float RegrowDuration => 0f;

		public bool StayShrinkedByMoves => false;

		public float StayShrinkedDuration => 0f;

		public int StayShrinkedMoves => 0;

		public bool AutoRegrow => false;

		public bool RegrowOnlyWhenMoving => false;

		public int ReferenceTailLength => 0;

		public float MinDurationMultiplier => 0f;

		public float MaxDurationMultiplier => 0f;

		public void Init(TailManager tailManager)
		{
		}

		public void UpdateDebugUI(float shrinkTimeLeft = -1f, float regrowTimeLeft = -1f, int movesLeft = -1)
		{
		}
	}
}
