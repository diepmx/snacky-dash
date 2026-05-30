using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPressFeedback : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler
{
	[Header("Animation Settings")]
	public float pressedScale;

	public float duration;

	public Ease ease;

	private bool isPressed;

	private Vector3 originalScale;

	private void Awake()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void ResetScale()
	{
	}
}
