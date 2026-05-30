using UnityEngine;

namespace JuicedUp.Common.Util
{
	public class ActivateRandomObject : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _objects;

		private int _selectedIndex;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private int GetRandomIndex()
		{
			return 0;
		}
	}
}
