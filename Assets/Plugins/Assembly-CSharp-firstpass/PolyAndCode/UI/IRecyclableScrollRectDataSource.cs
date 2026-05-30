using System.Collections.Generic;

namespace PolyAndCode.UI
{
	public interface IRecyclableScrollRectDataSource
	{
		int GetItemsCount();

		void SetCell(ICell cell, int index);

		void OnAllCellsInstantiated(List<ICell> cells);

		void Clear();
	}
}
