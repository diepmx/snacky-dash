using System;
using System.Collections.Generic;

namespace ConsentManagementProvider.Json
{
	[Serializable]
	public class UserConsentsWrapper
	{
		public List<ConsentableWrapper> vendors;

		public List<ConsentableWrapper> categories;
	}
}
