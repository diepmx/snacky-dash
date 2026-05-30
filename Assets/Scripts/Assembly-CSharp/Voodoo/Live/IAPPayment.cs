using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live
{
	public class IAPPayment : Payment, IPayment, IResultProvider
	{
		public RealCurrencyPrice price { get; set; }

		public event Action<string, Dictionary<string, object>> purchaseIAP
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

		public IAPPayment(RealCurrencyPrice price, Action<string, Dictionary<string, object>> purchaseMethod)
		{
		}

		public override void Validate()
		{
		}

		public override bool CanAfford()
		{
			return false;
		}

		public override void Start()
		{
		}
	}
}
