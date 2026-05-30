using UnityEngine;

namespace JuicedUp.Features.Support
{
	[CreateAssetMenu(fileName = "FreshdeskSettings", menuName = "Voodoo/Freshdesk/Create Settings")]
	public class FreshdeskSettings : ScriptableObject
	{
		private const string NAME = "FreshdeskSettings";

		public string _linkSuffix;

		public static FreshdeskSettings Get()
		{
			return null;
		}
	}
}
