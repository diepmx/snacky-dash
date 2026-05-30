using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live
{
	public abstract class Payment : IPayment, IResultProvider
	{
		private bool _isProcessingStatus;

		private Queue<PaymentState> _statusQueue;

		protected PaymentState _state;

		public PaymentState State => default(PaymentState);

		public Result Validation { get; protected set; }

		public Dictionary<string, object> ContextParameters { get; set; }

		public event Action<PaymentState> stateChanged
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

		public abstract void Validate();

		public void SetState(PaymentState state)
		{
		}

		private void ProcessNextStatus()
		{
		}

		public abstract bool CanAfford();

		public abstract void Start();
	}
}
