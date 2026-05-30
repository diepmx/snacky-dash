using System.Collections.Generic;

namespace ConsentManagementProvider
{
	public class SpCampaign
	{
		private CAMPAIGN_TYPE campaignType;

		private List<TargetingParam> targetingParams;

		private bool transitionCCPAAuth;

		private bool supportLegacyUSPString;

		public CAMPAIGN_TYPE CampaignType => default(CAMPAIGN_TYPE);

		public List<TargetingParam> TargetingParams => null;

		public bool TransitionCCPAAuth => false;

		public bool SupportLegacyUSPString => false;

		public SpCampaign(CAMPAIGN_TYPE campaignType, List<TargetingParam> targetingParams, bool transitionCCPAAuth = false, bool supportLegacyUSPString = false)
		{
		}
	}
}
