using System;

namespace JuicedUp.Common.SaveAndLoad
{
	public interface IDataRepository<T> where T : class, new()
	{
		T Data { get; }

		void Update(Action<T> mutator);

		void UpdateAndSave(Action<T> mutator);
	}
}
