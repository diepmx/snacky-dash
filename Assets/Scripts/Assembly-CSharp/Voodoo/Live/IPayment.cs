using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IPayment : IResultProvider
	{
		Dictionary<string, object> ContextParameters { get; set; }

		PaymentState State { get; }

		event Action<PaymentState> stateChanged;

		bool CanAfford();

		void SetState(PaymentState state);

		void Start();
	}
}
