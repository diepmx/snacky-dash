using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using CloudContent.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JuicedUp.Common.Config;
using UnityEngine.Networking;

namespace JuicedUp.Features.CloudContent
{
	public sealed class CloudContentLevelDownloader : ILevelDownloader
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public CloudContentLevelDownloader _003C_003E4__this;

			public string ccdPath;

			public CloudContentLevelsConfig config;

			internal UniTask<string> _003CDownloadStringAsync_003Eb__0(CancellationToken innerCt)
			{
				return default(UniTask<string>);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDownloadLevelAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<LevelDataSO> _003C_003Et__builder;

			public CloudContentLevelDownloader _003C_003E4__this;

			public string ccdPath;

			public CancellationToken ct;

			private UniTask<string>.Awaiter _003C_003Eu__1;

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
		private struct _003CDownloadStringAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<string> _003C_003Et__builder;

			public CloudContentLevelDownloader _003C_003E4__this;

			public string ccdPath;

			public CancellationToken ct;

			private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

			private UniTask<string>.Awaiter _003C_003Eu__1;

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
		private struct _003CFetchStringAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<string> _003C_003Et__builder;

			public string url;

			public int timeoutSeconds;

			public CancellationToken ct;

			private UnityWebRequest _003Crequest_003E5__2;

			private UniTask<UnityWebRequest>.Awaiter _003C_003Eu__1;

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

		private readonly RemoteConfigService _remoteConfigService;

		private CloudContentConfiguration _sdkConfig;

		public CloudContentLevelDownloader(RemoteConfigService remoteConfigService)
		{
		}

		public void InitializeSdk()
		{
		}

		[AsyncStateMachine(typeof(_003CDownloadStringAsync_003Ed__4))]
		public UniTask<string> DownloadStringAsync(string ccdPath, CancellationToken ct)
		{
			return default(UniTask<string>);
		}

		[AsyncStateMachine(typeof(_003CDownloadLevelAsync_003Ed__5))]
		public UniTask<LevelDataSO> DownloadLevelAsync(string ccdPath, CancellationToken ct)
		{
			return default(UniTask<LevelDataSO>);
		}

		private string BuildCdnUrl(string path)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFetchStringAsync_003Ed__7))]
		private static UniTask<string> FetchStringAsync(string url, int timeoutSeconds, CancellationToken ct)
		{
			return default(UniTask<string>);
		}
	}
}
