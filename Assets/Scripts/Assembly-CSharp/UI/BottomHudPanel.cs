using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.UI;
using JuicedUp.Features.Shop.Internal.Controllers;
using JuicedUp.Features.Shop.Internal.Notifiers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
	public class BottomHudPanel : MonoBehaviour
	{
		private enum BottomHudState
		{
			Home = 0,
			Shop = 1
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTryToActivateHomeViewAsync_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public BottomHudPanel _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Header("HomeButton settings:")]
		[SerializeField]
		private Button _homeButton;

		[SerializeField]
		private RectTransform _homeContent;

		[SerializeField]
		private GameObject _plug;

		[SerializeField]
		private TMP_Text _homeText;

		[Header("ShopButton settings:")]
		[SerializeField]
		private Button _shopButton;

		[SerializeField]
		private RectTransform _shopContent;

		[SerializeField]
		private TMP_Text _shopText;

		[Header("Marker:")]
		[SerializeField]
		private Transform _marker;

		[SerializeField]
		private float _yOffset;

		[SerializeField]
		private float _moveDuration;

		[Header("Swipe transition:")]
		[SerializeField]
		private MainNavigationTransitionController _navigationController;

		private RectTransform _shopButtonRectTransform;

		private RectTransform _homeButtonRectTransform;

		private RectTransform _markerRectTransform;

		private IShopViewControllerNotifier _shopViewControllerNotifier;

		private IShopViewController _shopViewController;

		private BottomHudState _currentState;

		[Inject]
		private void Construct(IShopViewControllerNotifier shopViewControllerNotifier, IShopViewController shopViewController)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnShopViewActivated()
		{
		}

		private void OnShopViewDeactivated()
		{
		}

		private void OnShopButtonClicked()
		{
		}

		private void OnHomeButtonClicked()
		{
		}

		private void TryToActivateShopView(bool playSwipe)
		{
		}

		[AsyncStateMachine(typeof(_003CTryToActivateHomeViewAsync_003Ed__27))]
		private UniTaskVoid TryToActivateHomeViewAsync(bool playSwipe)
		{
			return default(UniTaskVoid);
		}

		public void RequestActivateShopBySwipe()
		{
		}

		public void RequestActivateHomeBySwipe()
		{
		}

		private void SetupMarker(RectTransform targetSection)
		{
		}

		private void UpdateContent()
		{
		}
	}
}
