using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Voodoo.Live
{
	public class ConfigLoader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetConfigWithRetriesAsync_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ConfigResponse> _003C_003Et__builder;

			public int maxDelayMs;

			public CancellationToken ct;

			public ConfigLoader _003C_003E4__this;

			public string url;

			public string clientName;

			private ConfigResponse _003Cconfig_003E5__2;

			private int _003Cattempt_003E5__3;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<UnityWebRequest> _003C_003Eu__2;

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
		private struct _003CSendWebRequestAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<UnityWebRequest> _003C_003Et__builder;

			public ConfigResponse response;

			public CancellationToken token;

			public ConfigLoader _003C_003E4__this;

			private DateTime _003CstartTime_003E5__2;

			private UnityWebRequest _003Crequest_003E5__3;

			private UnityWebRequestAsyncOperation _003CasyncOperation_003E5__4;

			private CancellationTokenSource _003Ctimeout_003E5__5;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private int _timeoutInMilliseconds;

		private int _secondTimeoutInMilliseconds;

		public Action<string> OnConfigGet;

		private bool IsServerError(UnityWebRequest request)
		{
			return false;
		}

		private bool ShouldRetry(UnityWebRequest request)
		{
			return false;
		}

		public ConfigLoader(int timeoutInMilliseconds = -1, int secondTimeoutInMilliseconds = -1)
		{
		}

		public ConfigResponse GetConfig(string url)
		{
			return null;
		}

		private string GetRequestError(UnityWebRequest request, double duration)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetConfigWithRetriesAsync_003Ed__8))]
		public Task<ConfigResponse> GetConfigWithRetriesAsync(string url, string clientName, int maxDelayMs = 30000, CancellationToken ct = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendWebRequestAsync_003Ed__9))]
		private Task<UnityWebRequest> SendWebRequestAsync(ConfigResponse response, CancellationToken token = default(CancellationToken))
		{
			return null;
		}

		private UnityWebRequest SendWebRequest(ConfigResponse response)
		{
			return null;
		}

		private void UpdateConfigResponse(ConfigResponse config, UnityWebRequest request)
		{
		}
	}
}
