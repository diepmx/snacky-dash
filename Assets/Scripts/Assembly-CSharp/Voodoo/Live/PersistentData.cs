using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Voodoo.Live
{
	public class PersistentData : IBlackboard
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTrySave_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public PersistentData _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CTryToMigrateFrom_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string oldContextName;

			public PersistentData _003C_003E4__this;

			private FileIO _003ColdIO_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

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

		private Dictionary<string, string> _data;

		private FileIO _io;

		private bool _isDirty;

		private Task _saveTask;

		public PersistentData(string contextName)
		{
		}

		[AsyncStateMachine(typeof(_003CTryToMigrateFrom_003Ed__5))]
		private void TryToMigrateFrom(string oldContextName)
		{
		}

		public bool HasKey(string key)
		{
			return false;
		}

		public T Get<T>(string key)
		{
			return default(T);
		}

		public Dictionary<string, string> GetAll()
		{
			return null;
		}

		public void Set(string key, object value)
		{
		}

		public void Clear()
		{
		}

		public void Remove(string key)
		{
		}

		[AsyncStateMachine(typeof(_003CTrySave_003Ed__12))]
		public Task TrySave()
		{
			return null;
		}
	}
}
