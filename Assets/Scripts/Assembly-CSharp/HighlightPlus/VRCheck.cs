using UnityEngine;

namespace HighlightPlus
{
	internal static class VRCheck
	{
		public static bool isActive;

		public static bool isVrRunning;

		public static RenderTextureDescriptor vrTextureDescriptor;

		private static bool IsActive()
		{
			return false;
		}

		private static bool IsVrRunning()
		{
			return false;
		}

		private static RenderTextureDescriptor GetVRTextureDescriptor()
		{
			return default(RenderTextureDescriptor);
		}

		public static void Init()
		{
		}
	}
}
