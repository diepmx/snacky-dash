using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class ResourcesLoader : IAssetLoader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadAssetAsync_003Ed__2<T> : IAsyncStateMachine where T : Object
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public string key;

			public CancellationToken cancellationToken;

			private ResourceRequest _003Crequest_003E5__2;

			private UniTask<Object>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadPrefabAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<GameObject> _003C_003Et__builder;

			public string key;

			public CancellationToken cancellationToken;

			private ResourceRequest _003Crequest_003E5__2;

			private UniTask<Object>.Awaiter _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CLoadPrefabAsync_003Ed__0))]
		public UniTask<GameObject> LoadPrefabAsync(string key, CancellationToken cancellationToken)
		{
			return default(UniTask<GameObject>);
		}

		public GameObject LoadPrefab(string key)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadAssetAsync_003Ed__2<>))]
		public UniTask<T> LoadAssetAsync<T>(string key, CancellationToken cancellationToken) where T : Object
		{
			return default(UniTask<T>);
		}

		public T LoadAsset<T>(string key) where T : Object
		{
			return null;
		}

		public void UnloadAsset(Object asset)
		{
		}
	}
}
