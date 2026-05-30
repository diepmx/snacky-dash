using UnityEngine;
using UnityEngine.UI;

namespace Shapes2D
{
	public class Game : MonoBehaviour
	{
		public Bird bird;

		public GameObject pipeSetPrefab;

		public float pipeDistance;

		public float scrollSpeed;

		public Transform pipeSpawnLocation;

		public Transform pipeKillLocation;

		public float pipeVariation;

		private float pipeTimer;

		public Button startButton;

		public Button resetButton;

		public Text score;

		private Transform pipes;

		public Shape ground;

		private void Start()
		{
		}

		private void AdjustWidths()
		{
		}

		public void OnStartButton()
		{
		}

		private void Update()
		{
		}
	}
}
