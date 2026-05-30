using System;
using System.Collections.Generic;

namespace Voodoo.Live
{
	public static class PersistencyRetroCompatibility
	{
		public static Dictionary<string, string> FormerToNewerKeyWithPrefix;

		public static Dictionary<string, string> FormerToNewerKey;

		public static Dictionary<string, Type> KeyTargetType;

		public static void Apply(string prefix, IBlackboard blackboard, string id)
		{
		}

		public static object GetValue(string key, Type type)
		{
			return null;
		}
	}
}
