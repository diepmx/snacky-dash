using System;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class GCMDataWrapper
	{
		public SPGCMData.Status? ad_storage;

		public SPGCMData.Status? analytics_storage;

		public SPGCMData.Status? ad_user_data;

		public SPGCMData.Status? ad_personalization;
	}
}
