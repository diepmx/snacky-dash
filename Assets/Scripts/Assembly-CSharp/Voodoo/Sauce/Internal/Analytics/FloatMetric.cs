namespace Voodoo.Sauce.Internal.Analytics
{
	public struct FloatMetric
	{
		public float Min;

		public float Max;

		public float Average;

		public float Variance;

		public FloatMetric(float min, float max, float average, float variance = 0f)
		{
			Min = 0f;
			Max = 0f;
			Average = 0f;
			Variance = 0f;
		}
	}
}
