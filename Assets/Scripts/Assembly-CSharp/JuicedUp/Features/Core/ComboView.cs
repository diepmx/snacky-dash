using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class ComboView : MonoBehaviour
	{
		private struct TierResolution
		{
			public string[] WordKeys;

			public MMF_Player TierFeedback;

			public MMF_Player MultiplierFeedback;

			public TMP_Text TitleBack;

			public TMP_Text TitleFront;

			public TMP_Text ValueBack;

			public TMP_Text ValueFront;

			public Action Haptic;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHideRootAfterDelayAsync_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ComboView _003C_003E4__this;

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

		private const string PlusPrefixKey = "combo_ui_plus_prefix";

		private const string TotalLabelKey = "combo_ui_total_label";

		private const string StepValueFormat = "{0}{1}<sprite name=Coin>";

		private const string TotalValueFormat = "{0} {1}{2}<sprite name=Coin>";

		private static readonly string[] Tier1WordKeys;

		private static readonly string[] Tier2WordKeys;

		private static readonly string[] Tier3WordKeys;

		[Header("Root")]
		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private float _timeToForceDisable;

		[Header("Tier Feedbacks")]
		[SerializeField]
		private MMF_Player _tier1Feedback;

		[SerializeField]
		private MMF_Player _tier2Feedback;

		[SerializeField]
		private MMF_Player _tier3Feedback;

		[Header("Multiplier Feedbacks")]
		[SerializeField]
		private MMF_Player _multiplierFeedback;

		[SerializeField]
		private MMF_Player _multiplierTier3Feedback;

		[Header("Tier Titles (back / front pairs)")]
		[SerializeField]
		private TMP_Text _tier1Title;

		[SerializeField]
		private TMP_Text _tier1TitleFront;

		[SerializeField]
		private TMP_Text _tier2Title;

		[SerializeField]
		private TMP_Text _tier2TitleFront;

		[SerializeField]
		private TMP_Text _tier3Title;

		[SerializeField]
		private TMP_Text _tier3TitleFront;

		[Header("Value Texts (back / front pairs)")]
		[SerializeField]
		private TMP_Text _valueText;

		[SerializeField]
		private TMP_Text _valueTextFront;

		[SerializeField]
		private TMP_Text _valueTier3Text;

		[SerializeField]
		private TMP_Text _valueTier3TextFront;

		private int _lastWordIndex;

		private string[] _lastWordPool;

		private TMP_Text _lastValueBack;

		private TMP_Text _lastValueFront;

		private CancellationTokenSource _hideRootCts;

		public void ShowCombo(int chainCount, int coins)
		{
		}

		public void ShowComboFinal(int chainCount, int totalCoins)
		{
		}

		public void ShowComboTotal(int total)
		{
		}

		private void DisplayCombo(int chainCount, string valueText)
		{
		}

		private static string BuildStepText(int coins)
		{
			return null;
		}

		private static string BuildTotalText(int total)
		{
			return null;
		}

		public void ResetCombo()
		{
		}

		private void OnDestroy()
		{
		}

		private void ScheduleRootHide()
		{
		}

		[AsyncStateMachine(typeof(_003CHideRootAfterDelayAsync_003Ed__38))]
		private UniTaskVoid HideRootAfterDelayAsync(CancellationToken token)
		{
			return default(UniTaskVoid);
		}

		private TierResolution ResolveTier(int comboStep)
		{
			return default(TierResolution);
		}

		private string PickNonRepeatingWord(string[] pool)
		{
			return null;
		}

		private static void SetText(TMP_Text tmp, string value)
		{
		}
	}
}
