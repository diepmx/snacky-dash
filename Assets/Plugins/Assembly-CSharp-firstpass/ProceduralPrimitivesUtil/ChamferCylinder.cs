namespace ProceduralPrimitivesUtil
{
	public class ChamferCylinder : PPCircularBase
	{
		public float radius;

		public float height;

		public float fillet;

		public bool flatFillet;

		public int capSegs;

		public int heightSegs;

		public int filletSegs;

		protected override void CreateMesh()
		{
		}
	}
}
