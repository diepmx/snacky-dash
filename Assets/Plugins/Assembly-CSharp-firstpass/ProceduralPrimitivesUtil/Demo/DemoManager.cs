using UnityEngine;

namespace ProceduralPrimitivesUtil.Demo
{
	public class DemoManager : MonoBehaviour
	{
		private static DemoManager instance;

		public Material[] demoMaterials;

		public static DemoManager Instance => null;
	}
}
