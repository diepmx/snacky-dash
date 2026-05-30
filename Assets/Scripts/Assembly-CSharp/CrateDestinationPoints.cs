using System.Collections.Generic;
using UnityEngine;

public class CrateDestinationPoints : MonoBehaviour
{
	[SerializeField]
	private List<DestinationPointInCrate> _points;

	public IReadOnlyList<DestinationPointInCrate> Points => null;

	public bool IsComplete { get; set; }
}
