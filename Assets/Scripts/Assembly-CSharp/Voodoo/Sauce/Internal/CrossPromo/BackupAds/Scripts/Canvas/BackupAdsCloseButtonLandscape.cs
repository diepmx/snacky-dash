using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Sauce.Internal.CrossPromo.BackupAds.Scripts.Canvas
{
	[RequireComponent(typeof(Button))]
	public class BackupAdsCloseButtonLandscape : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCheckOrientation_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BackupAdsCloseButtonLandscape _003C_003E4__this;

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
			public _003CCheckOrientation_003Ed__14(int _003C_003E1__state)
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

		private Button _button;

		private RectTransform _rect;

		private ScreenOrientation _currentOrientation;

		private Coroutine _refreshCoroutine;

		[field: SerializeField]
		public float PortraitSize { get; private set; }

		[field: SerializeField]
		public float HorizontalSize { get; private set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckOrientation_003Ed__14))]
		private IEnumerator CheckOrientation()
		{
			return null;
		}

		private void UpdateButtonSize()
		{
		}
	}
}
