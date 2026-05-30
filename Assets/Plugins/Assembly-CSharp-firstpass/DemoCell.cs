using PolyAndCode.UI;
using UnityEngine;
using UnityEngine.UI;

public class DemoCell : MonoBehaviour, ICell
{
	public Text nameLabel;

	public Text genderLabel;

	public Text idLabel;

	private ContactInfo _contactInfo;

	private int _cellIndex;

	private void Start()
	{
	}

	public void ConfigureCell(ContactInfo contactInfo, int cellIndex)
	{
	}

	private void ButtonListener()
	{
	}
}
