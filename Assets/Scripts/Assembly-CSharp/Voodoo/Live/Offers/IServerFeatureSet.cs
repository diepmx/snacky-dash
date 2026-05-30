using System.Collections.Generic;

namespace Voodoo.Live.Offers
{
	public interface IServerFeatureSet : IServerFeature
	{
		List<ProductDTO> Features { get; set; }
	}
}
