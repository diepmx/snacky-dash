using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CloudContent.Data;
using CloudContent.Interface;
using CloudContent.Models;
using Voodoo.Sauce.Debugger;

namespace CloudContent.Sample
{
	public class CloudContentDebugger : CustomDebugger
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetString_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public File file;

			public CloudContentDebugger _003C_003E4__this;

			public Screen screen;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private CloudContentConfiguration _config;

		private ICacheApi _cache;

		private Dictionary<string, string> _content;

		public override int GetOrderIndex()
		{
			return 0;
		}

		public override string GetTitle()
		{
			return null;
		}

		public override void SetupScreen(Screen screen)
		{
		}

		public void Refresh(Screen screen)
		{
		}

		private void DisplayCache(Screen screen)
		{
		}

		private void DisplayConfig(Screen screen)
		{
		}

		private string GetEnvironment()
		{
			return null;
		}

		private string GetBucketId()
		{
			return null;
		}

		private void SetTimeoutInSeconds(string timeout)
		{
		}

		private string GetTimeoutInSeconds()
		{
			return null;
		}

		private void SetAttempts(string attempts)
		{
		}

		private string GetAttempts()
		{
			return null;
		}

		private void DisplayContent(Screen screen)
		{
		}

		private void ClearCache()
		{
		}

		private void DisplayFile(Screen screen, File file)
		{
		}

		[AsyncStateMachine(typeof(_003CGetString_003Ed__18))]
		private Task GetString(Screen screen, File file)
		{
			return null;
		}

		private void RefreshScreen(Screen screen)
		{
		}
	}
}
