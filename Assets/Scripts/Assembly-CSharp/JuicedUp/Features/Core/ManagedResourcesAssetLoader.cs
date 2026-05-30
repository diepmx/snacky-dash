using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public sealed class ManagedResourcesAssetLoader : IManagedAssetLoader
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0<TScriptable> where TScriptable : ScriptableObject
		{
			public ResourceRequest request;

			internal bool _003CLoadScriptableObject_003Eb__0()
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadAsset_003Ed__5<TComponent> : IAsyncStateMachine where TComponent : MonoBehaviour
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<TComponent> _003C_003Et__builder;

			public string assetKey;

			public ManagedResourcesAssetLoader _003C_003E4__this;

			public CancellationToken token;

			public Transform parent;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadScriptableObject_003Ed__6<TScriptable> : IAsyncStateMachine where TScriptable : ScriptableObject
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<TScriptable> _003C_003Et__builder;

			public string assetKey;

			public CancellationToken token;

			public ManagedResourcesAssetLoader _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0<TScriptable> _003C_003E8__1;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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
		private struct _003CPreloadAsset_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string assetKey;

			public ManagedResourcesAssetLoader _003C_003E4__this;

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

		private static readonly TimeSpan LoadTimeout;

		private readonly Dictionary<string, GameObject> _prefabCache;

		private readonly Dictionary<string, ScriptableObject> _scriptableCache;

		private readonly Dictionary<string, List<GameObject>> _instantiates;

		[AsyncStateMachine(typeof(_003CPreloadAsset_003Ed__4))]
		public UniTask PreloadAsset(string assetKey, CancellationToken token)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadAsset_003Ed__5<>))]
		public UniTask<TComponent> LoadAsset<TComponent>(string assetKey, Transform parent, CancellationToken token) where TComponent : MonoBehaviour
		{
			return default(UniTask<TComponent>);
		}

		[AsyncStateMachine(typeof(_003CLoadScriptableObject_003Ed__6<>))]
		public UniTask<TScriptable> LoadScriptableObject<TScriptable>(string assetKey, CancellationToken token) where TScriptable : ScriptableObject
		{
			return default(UniTask<TScriptable>);
		}

		public void DestroyAllAssetsByKey(string assetKey)
		{
		}

		public void UnloadAllAssetsByKey(string assetKey)
		{
		}
	}
}
