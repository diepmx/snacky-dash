using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Voodoo.Live.Utils;

namespace Voodoo.Live
{
	public abstract class ReloadableClient : IReloadableClient, IClient, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReload_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ReloadableClient _003C_003E4__this;

			private string _003Curl_003E5__2;

			private string _003CpreviousPayload_003E5__3;

			private TaskAwaiter<ConfigResponse> _003C_003Eu__1;

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

		private bool _disposed;

		private CancellationTokenSource _reloadCTS;

		private readonly List<string> _activeBlockers;

		private bool _isReloading;

		private bool _hasPendingRefresh;

		private DateTime _lastReloadAppliedAt;

		private ReloadState _lastCompletedState;

		protected ConfigLoader _configLoader;

		protected CacheSystem _cache;

		protected abstract string ClientName { get; }

		protected abstract string ConfigStatusEventName { get; }

		public IUrlHandler UrlHandler { get; protected set; }

		public ConfigResponse ConfigResponse { get; protected set; }

		public string Payload { get; protected set; }

		public ReloadState CurrentReloadState => default(ReloadState);

		public DateTime LastReloadAppliedAt => default(DateTime);

		public bool HasBlockers => false;

		public IReadOnlyList<string> ActiveBlockers => null;

		public event Action<ConfigResponse> requestCompleted
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

		public event Action reloadApplied
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

		public event Action<string> reloadFailed
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

		public void AddReloadBlocker(string blocker)
		{
		}

		public void RemoveReloadBlocker(string blocker)
		{
		}

		[AsyncStateMachine(typeof(_003CReload_003Ed__44))]
		public Task Reload()
		{
			return null;
		}

		protected virtual void ApplyReload()
		{
		}

		protected abstract void ProcessPayload();

		public void CleanCache()
		{
		}

		private void InvokeRequestCompletedSafe(ConfigResponse cr)
		{
		}

		private void TrackNetworkResult(ConfigResponse response)
		{
		}

		private void TrackReloadDeferred()
		{
		}

		private void TrackReloadSuccess()
		{
		}

		private void TrackReloadFailed(string errorMessage)
		{
		}

		private void TrackEvent(string eventName, Dictionary<string, object> contextProperties = null)
		{
		}

		public void Dispose()
		{
		}

		protected abstract void DisposeSubclass();
	}
}
