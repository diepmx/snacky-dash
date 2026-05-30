namespace Voodoo.Live
{
	public abstract class BasePrice : IPrice, IResultProvider
	{
		protected Result _validation;

		public string type { get; set; }

		public Result Validation => null;

		public abstract PriceDTO ToDTO();

		public abstract void Validate();

		public T WithValidation<T>(Result validation) where T : BasePrice
		{
			return null;
		}

		public BasePrice WithValidation(Result validation)
		{
			return null;
		}
	}
}
