using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

namespace JuicedUp.Common.Hints
{
	public class HintView : MonoBehaviour
	{
		[SerializeField]
		private MMF_Player upFeedback;

		[SerializeField]
		private MMF_Player downFeedback;

		[SerializeField]
		private TextMeshProUGUI label;

		private IObjectPool<HintView> _pool;

		public void SetPool(IObjectPool<HintView> pool)
		{
		}

		public void Initialize(string value, HintManager.Direction direction)
		{
		}

		public void Destroy()
		{
		}
	}
}
