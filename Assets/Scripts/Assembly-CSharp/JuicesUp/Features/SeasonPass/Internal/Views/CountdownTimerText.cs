using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;
using VContainer;

namespace JuicesUp.Features.SeasonPass.Internal.Views
{
	internal class CountdownTimerText : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdateTimerLoop_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CountdownTimerText _003C_003E4__this;

			public CancellationToken ctoken;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

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

		private const string ENDED_LOCALIZATION_KEY = "FINISHED";

		[SerializeField]
		private TMP_Text _timerText;

		private IBattlePassAppBridge _appBridge;

		private DateTime? _targetTime;

		[Inject]
		public void Construct(IBattlePassAppBridge bridge)
		{
		}

		private void OnEnable()
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		public void SetTargetTime(DateTime targetTime, IBattlePassAppBridge bridge = null)
		{
		}

		public void Clear()
		{
		}

		private void StartTimerLoop()
		{
		}

		private void UpdateTimerText()
		{
		}

		[AsyncStateMachine(typeof(_003CUpdateTimerLoop_003Ed__12))]
		private UniTaskVoid UpdateTimerLoop(CancellationToken ctoken)
		{
			return default(UniTaskVoid);
		}
	}
}
