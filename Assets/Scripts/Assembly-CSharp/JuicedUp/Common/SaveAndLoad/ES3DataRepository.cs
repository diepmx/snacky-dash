using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace JuicedUp.Common.SaveAndLoad
{
	public class ES3DataRepository<T> : DataRepositoryBase, IDataRepository<T>, IFlushDataRepository where T : class, new()
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSaveAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ES3DataRepository<T> _003C_003E4__this;

			public CancellationToken token;

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

		private readonly string _key;

		private readonly float _saveDelayInSec;

		private T _data;

		private bool _isDirty;

		private CancellationTokenSource _debounceCts;

		public T Data => null;

		public ES3DataRepository(string key, float saveDelayInSec)
		{
		}

		public void Update(Action<T> mutator)
		{
		}

		public void UpdateAndSave(Action<T> mutator)
		{
		}

		public void Flush()
		{
		}

		private void RestartDebounce()
		{
		}

		[AsyncStateMachine(typeof(ES3DataRepository<>._003CSaveAsync_003Ed__12))]
		private UniTask SaveAsync(CancellationToken token)
		{
			return default(UniTask);
		}

		private void Save()
		{
		}

		private void Load()
		{
		}

		private void TryDeleteUnencryptedKey()
		{
		}

		private void CancelDebounce()
		{
		}
	}
}
