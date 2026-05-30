using UnityEngine;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Debugger
{
	public class OffersSubHeader : SubHeader
	{
		[Header("Settings")]
		public int FeaturesPerPage;

		[SerializeField]
		private VoodooLivePaginationDebugger _paginationDebuggerPrefab;

		public IFeature[] features;

		private Transform _contentTR;

		private VoodooLivePaginationDebugger _paginationDebugger;

		public void Init(IFeature[] features, Transform contentTR)
		{
		}

		public void ClearCurrentPage()
		{
		}

		public void DisplayPage()
		{
		}

		public OffersDebugUI GetDebugUI(IFeature feature)
		{
			return null;
		}
	}
}
