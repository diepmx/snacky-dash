using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core.Layout
{
	public class LevelCameraFitterInstaller : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnLevelBuildAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public LevelCameraFitterInstaller _003C_003E4__this;

			private Cysharp.Threading.Tasks.YieldAwaitable.Awaiter _003C_003Eu__1;

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

		[SerializeField]
		private LevelCameraFitter _levelCameraFitter;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnLevelBuilt(LevelDataSO arg1, LevelMeta arg2)
		{
		}

		[AsyncStateMachine(typeof(_003COnLevelBuildAsync_003Ed__4))]
		private UniTaskVoid OnLevelBuildAsync()
		{
			return default(UniTaskVoid);
		}
	}
}
