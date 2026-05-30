using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	[CreateAssetMenu(menuName = "JuicedUp/Crate Visual Config Provider", fileName = "CrateVisualConfigProvider")]
	public class CrateVisualConfigProvider : ScriptableObject
	{
		[SerializeField]
		private CrateVisualConfig _control;

		[SerializeField]
		private List<NamedCrateVisualConfigVariant> _variants;

		public CrateVisualConfig Resolve(string key)
		{
			return null;
		}
	}
}
