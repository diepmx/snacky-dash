using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Voodoo.Live.Shop.UI
{
	public abstract class GameShopBase : MonoBehaviour, IGameShop
	{
		public event Action OnShopOpened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnShopClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void Init();

		public abstract void OpenShop(string sourceId, string sourceName);

		protected void NotifyShopOpened()
		{
		}

		protected void NotifyShopClosed()
		{
		}
	}
}
