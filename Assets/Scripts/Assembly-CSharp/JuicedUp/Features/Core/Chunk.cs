using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JuicedUp.Features.Core
{
	public class Chunk : MonoBehaviour
	{
		public static Action<CameraGameType> OnChunkInstantiated;

		public Tilemap tilemapChunk;

		public CameraGameType chunkCameraType;

		[HideInInspector]
		public CameraSwitcher cameraSwitcher;

		[HideInInspector]
		public float offSetX;

		[HideInInspector]
		public float speedPlayer;

		public void InitChunk()
		{
		}

		private void SetPlayerSpeed()
		{
		}
	}
}
