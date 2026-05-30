using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Voodoo.Live
{
	public class FileIO
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSave_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Dictionary<string, string> data;

			public FileIO _003C_003E4__this;

			private string _003CtempFilePath_003E5__2;

			private StreamWriter _003Cwriter_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TaskAwaiter _003C_003Eu__1;

			private ValueTaskAwaiter _003C_003Eu__2;

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

		private readonly string directoryPath;

		private readonly string filePath;

		public FileIO(string fileName)
		{
		}

		public Dictionary<string, string> Read()
		{
			return null;
		}

		private void CreateDirectoryIfNotExists()
		{
		}

		[AsyncStateMachine(typeof(_003CSave_003Ed__5))]
		public Task Save(Dictionary<string, string> data)
		{
			return null;
		}

		internal void Delete()
		{
		}
	}
}
