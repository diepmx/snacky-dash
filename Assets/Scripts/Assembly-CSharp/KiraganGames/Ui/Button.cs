using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace KiraganGames.Ui
{
	public class Button : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler
	{
		[Serializable]
		private class State
		{
			public RectTransform Rect;

			public Vector2 Position;

			public Vector2 Scale;
		}

		[SerializeField]
		private MMF_Player downFeedback;

		[SerializeField]
		private MMF_Player upFeedback;

		[SerializeField]
		private List<State> initialStates;

		[SerializeField]
		private UnityEvent onPointerDown;

		[SerializeField]
		private UnityEvent onPointerUp;

		[SerializeField]
		private bool useDownVibration;

		[SerializeField]
		private bool useUpVibration;

		[SerializeField]
		private float downAmplitude;

		[SerializeField]
		private float downDuration;

		[SerializeField]
		private float upAmplitude;

		[SerializeField]
		private float upDuration;

		[SerializeField]
		private bool useClickHandler;

		private bool isInitialized;

		public event Action ButtonPressedDown
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

		public event Action ButtonPressedUp
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

		private void OnEnable()
		{
		}

		public void FirePress()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
