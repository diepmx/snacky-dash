using UnityEngine;

namespace Deus
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance;

		public static T Get => null;

		protected virtual bool UseDontDestroyOnLoad => false;

		protected virtual void Awake()
		{
		}
	}
}
