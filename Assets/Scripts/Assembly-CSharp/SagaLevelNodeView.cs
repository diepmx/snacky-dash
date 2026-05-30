using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SagaLevelNodeView : MonoBehaviour
{
	[Header("Core")]
	[SerializeField]
	private Image _nodeImage;

	[SerializeField]
	private TMP_Text _numberText;

	[Header("Optional")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	public void Render(int levelNumber)
	{
	}
}
