using JuicedUp.Features.Core.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.Privacy.UI
{
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(GraphicRaycaster))]
	public class LoadingScreen : BasePopupView
	{
		[SerializeField]
		private Image _spinner;

		[SerializeField]
		private float _speed;

		private void Update()
		{
		}
	}
}
