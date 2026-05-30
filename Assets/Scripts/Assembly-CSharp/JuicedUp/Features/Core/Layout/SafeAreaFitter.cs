using UnityEngine;
using UnityEngine.UI;

namespace JuicedUp.Features.Core.Layout
{
	[RequireComponent(typeof(RectTransform))]
	public class SafeAreaFitter : MonoBehaviour
	{
		[Tooltip("On iPhone, overrides the bottom safe area with this canvas-unit margin (equivalent to the 'Bottom' field in RectTransform).")]
		[SerializeField]
		private float _iPhoneFooterMarginOverride;

		[Header("Debug")]
		[SerializeField]
		private bool _isIPhoneDebug;

		[SerializeField]
		private Image[] _debugImages;

		private RectTransform _rectTransform;

		private Rect _lastSafeArea;

		private int _lastScreenWidth;

		private int _lastScreenHeight;

		private bool _isIPhone;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void DisplayGuides(bool show)
		{
		}

		private void Apply()
		{
		}
	}
}
