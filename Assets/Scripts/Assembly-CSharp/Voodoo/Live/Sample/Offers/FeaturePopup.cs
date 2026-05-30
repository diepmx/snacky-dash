using UnityEngine;
using Voodoo.Live.Offers;

namespace Voodoo.Live.Sample.Offers
{
	public abstract class FeaturePopup : MonoBehaviour, IFeaturePopup
	{
		protected IFeature _feature;

		public void Initialize(IFeature feature)
		{
		}

		protected void OnDisable()
		{
		}

		public abstract void Show();

		public virtual void Hide()
		{
		}

		public virtual void Purchase()
		{
		}

		public virtual void OnStatusChanged(string status, IFeature feature)
		{
		}
	}
}
