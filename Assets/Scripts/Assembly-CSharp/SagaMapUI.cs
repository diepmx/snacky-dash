using UnityEngine;

public class SagaMapUI : MonoBehaviour
{
	[Header("Wiring")]
	[SerializeField]
	private DifficultyStyleDatabase styleDb;

	[SerializeField]
	private SagaLevelNodeView[] slots;

	public void Render(int currentLevelNumber)
	{
	}
}
