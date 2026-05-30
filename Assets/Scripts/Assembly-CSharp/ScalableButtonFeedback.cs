using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScalableButtonFeedback : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler
{
	[Header("Références")]
	[Tooltip("La transformation à scaler (laisser vide pour scaler l'objet actuel)")]
	[SerializeField]
	private Transform pressTarget;

	[Header("Animation de Pression (Press)")]
	[SerializeField]
	private float pressScale;

	[SerializeField]
	private float pressDownDuration;

	[SerializeField]
	private float pressUpDuration;

	[SerializeField]
	private Ease pressUpEase;

	[Header("Animation de Notification (Pulse)")]
	[SerializeField]
	private Vector3 pulsePunch;

	[SerializeField]
	private float pulseDuration;

	[SerializeField]
	private int pulseVibrato;

	[SerializeField]
	private float pulseElasticity;

	private Vector3 _baseScale;

	private Tween _pressTween;

	private Tween _pulseTween;

	private Button targetButton;

	private void Awake()
	{
	}

	private void OnDisable()
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

	public void TriggerPulse(float delay = 0f)
	{
	}

	private void PlayPressDown()
	{
	}

	private void PlayPressUp()
	{
	}
}
