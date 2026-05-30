using DG.Tweening;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	public class ChunkTunnelView : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private MeshRenderer _rendererEntrance;

		[Header("Tweens")]
		[SerializeField]
		private float _enterDuration;

		[SerializeField]
		private Vector3 _enterPunchScale;

		[SerializeField]
		private Ease _enterEase;

		public void SetMaterial(Material material)
		{
		}

		public void AnimateEntrance()
		{
		}
	}
}
