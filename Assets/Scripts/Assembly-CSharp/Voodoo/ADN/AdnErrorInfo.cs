using System.Collections.Generic;

namespace Voodoo.ADN
{
	public class AdnErrorInfo
	{
		public int Code { get; private set; }

		public string Message { get; private set; }

		public AdnErrorInfo(IDictionary<string, object> errorInfoDictionary)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
