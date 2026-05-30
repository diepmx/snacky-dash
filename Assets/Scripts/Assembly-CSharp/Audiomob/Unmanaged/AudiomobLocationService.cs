using Audiomob.Internal;
using UnityEngine;

namespace Audiomob.Unmanaged
{
	public class AudiomobLocationService : ILocationService
	{
		public bool IsEnabledByUser => false;

		public GeoStatus Status => default(GeoStatus);

		public LocationInfo LastData => default(LocationInfo);

		public void Start()
		{
		}
	}
}
