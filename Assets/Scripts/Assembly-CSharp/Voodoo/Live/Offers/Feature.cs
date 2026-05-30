using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Voodoo.Live.Offers
{
	public abstract class Feature : Conditionnal, IFeature, IConditionnal, IDisposable, IResultProvider, IPurchasable, IResettable
	{
		protected Product _product;

		protected Result _validation;

		private bool _isProcessingStatus;

		private Queue<string> _statusQueue;

		protected string _status;

		public const string FeaturesFolderName = "Features/";

		public const string FeatureFolderPath = "VoodooLive/Features/";

		public string id { get; set; }

		public string name { get; set; }

		public string[] triggers { get; set; }

		public string campaign { get; set; }

		public string campaignId { get; set; }

		public FeatureVisual visual { get; set; }

		public string type { get; set; }

		public string Status => null;

		public string LastTrigger { get; private set; }

		public Result Validation => null;

		protected bool AreTriggersValid => false;

		public virtual bool ShouldDisplayBadges => false;

		public override IBlackboard Blackboard => null;

		public virtual Product Product => null;

		public IPrice Price => null;

		public IReward Reward => null;

		public event Action<string, IFeature> statusChanged
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

		public virtual void Validate()
		{
		}

		public T WithValidation<T>(Result validation) where T : Feature
		{
			return null;
		}

		public Feature WithValidation(Result validation)
		{
			return null;
		}

		public void InvalidateFeature()
		{
		}

		public void SetStatus(string status)
		{
		}

		private void ProcessNextStatus()
		{
		}

		public bool HasTrigger(string trigger)
		{
			return false;
		}

		public virtual bool TryTrigger(string trigger, bool forceTrigger = false, string sourceType = null, string sourceValue = null)
		{
			return false;
		}

		private void IncreaseTriggerAttempts(string trigger, string sourceType, string sourceValue)
		{
		}

		public bool CanUseBadge(List<string> ignoreKeys = null)
		{
			return false;
		}

		public virtual void Purchase()
		{
		}

		protected void SetTransactionData(Transaction transaction)
		{
		}

		public virtual Dictionary<string, object> GetContextParameters()
		{
			return null;
		}

		public virtual void RecoverTransaction(Transaction transaction)
		{
		}

		protected virtual void OnTransactionCompleted(Transaction transaction, bool succeed)
		{
		}

		protected virtual void IncrementPurchase()
		{
		}

		public override void Dispose()
		{
		}

		public virtual void Reset()
		{
		}
	}
}
