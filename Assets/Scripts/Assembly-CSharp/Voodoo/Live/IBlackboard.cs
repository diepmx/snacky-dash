using System.Collections.Generic;

namespace Voodoo.Live
{
	public interface IBlackboard
	{
		bool HasKey(string key);

		void Set(string key, object value);

		T Get<T>(string key);

		Dictionary<string, string> GetAll();

		void Remove(string key);

		void Clear();
	}
}
