using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live
{
	public class Transaction : IResultProvider
	{
		private IPayment _payment;

		private TransactionReceipt _receipt;

		public readonly ItemQuantity[] rewards;

		public bool IsSuccess { get; private set; }

		public TransactionReceipt Receipt => null;

		public Result Validation { get; private set; }

		public event Func<Transaction, bool> rewardingFunc
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

		public event Action<Transaction, bool> transactionCompleted
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

		public Transaction(TransactionReceipt receipt, IInventory inventory)
		{
		}

		public Transaction(string purchaseId, IPrice price, IReward reward, Dictionary<string, object> contextParameters = null)
		{
		}

		public void Start()
		{
		}

		private void OnPaymentStateChanged(PaymentState state)
		{
		}

		public void ValidatePayment()
		{
		}

		public void Fail()
		{
		}

		private void Reward()
		{
		}

		private void CompleteTransaction(bool isSuccess)
		{
		}

		public void Dispose()
		{
		}

		public void Validate()
		{
		}
	}
}
