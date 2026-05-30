namespace Voodoo.Live.Offers
{
	public interface IFeatureDTO
	{
		string type { get; }

		IFeature ToValidFormat();
	}
}
