using System.Collections.Generic;
using UnityEngine;

namespace Shapes2D
{
	public class Spawner : MonoBehaviour
	{
		public GameObject prefab;

		private float interval;

		private int count;

		private bool dynamic;

		private bool optimizePolygons;

		private int shapeType;

		private bool randomStyle;

		private float timer;

		private int spawned;

		private bool done;

		private float scale;

		private List<Shape> shapes;

		private float deltaTime;

		private void Start()
		{
		}

		private void OnGUI()
		{
		}

		private void Update()
		{
		}
	}
}
