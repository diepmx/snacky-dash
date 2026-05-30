using System.Collections.Generic;

namespace Voodoo.ADN
{
	public class AdnAdInfo
	{
		public string Name { get; private set; }

		public string Id { get; private set; }

		public string AdFormat { get; private set; }

		public double Revenue { get; private set; }

		public string CreativeId { get; private set; }

		public AdnAdInfo(IDictionary<string, object> adInfoDictionary)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
