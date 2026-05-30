using System;

namespace Voodoo.Live.Shop.UI
{
	public interface IGameShop
	{
		event Action OnShopOpened;

		event Action OnShopClosed;

		void Init();

		void OpenShop(string sourceId, string sourceName);
	}
}
