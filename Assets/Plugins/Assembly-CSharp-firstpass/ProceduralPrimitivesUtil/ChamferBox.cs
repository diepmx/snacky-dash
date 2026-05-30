namespace ProceduralPrimitivesUtil
{
	public class ChamferBox : PPBase
	{
		public float width;

		public float length;

		public float height;

		public float fillet;

		public bool flatTop;

		public bool flatBottom;

		public int widthSegs;

		public int lengthSegs;

		public int heightSegs;

		public int filletSegs;

		protected override void CreateMesh()
		{
		}
	}
}
