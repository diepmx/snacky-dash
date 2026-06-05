using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class ChunkTunnelView : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private MeshRenderer _rendererEntrance;

		[Header("Tweens")]
		[SerializeField] private float _enterDuration = 0.2f;
		[SerializeField] private Vector3 _enterPunchScale = new Vector3(0.3f, 0.3f, 0f);
		[SerializeField] private Ease _enterEase = Ease.OutBack;

		/// <summary>Apply a shared material to the entrance mesh (for color-coding by tunnel group).</summary>
		public void SetMaterial(Material material)
		{
			if (_rendererEntrance != null && material != null)
				_rendererEntrance.material = material;
		}

		/// <summary>Play a punch-scale animation when the snake enters this tunnel chunk.</summary>
		public void AnimateEntrance()
		{
			transform.DOPunchScale(_enterPunchScale, _enterDuration, vibrato: 1, elasticity: 0.5f)
				.SetEase(_enterEase);
		}
	}
}
