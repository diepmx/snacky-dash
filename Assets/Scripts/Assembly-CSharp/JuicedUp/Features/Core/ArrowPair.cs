using System.Collections.Generic;
using UnityEngine;

namespace JuicedUp.Features.Core
{
	/// <summary>
	/// Liên kết 2 ArrowSwitchController cùng SwitchID.
	/// Khi snake đi qua một arrow: arrow đó flip ngay lập tức,
	/// arrow còn lại (partner) cũng flip đồng thời.
	/// </summary>
	public sealed class ArrowPair
	{
		private readonly ArrowSwitchController _arrowA;
		private readonly ArrowSwitchController _arrowB;

		public ArrowPair(ArrowSwitchController arrowA, ArrowSwitchController arrowB)
		{
			_arrowA = arrowA;
			_arrowB = arrowB;
		}

		/// <summary>
		/// Gọi khi snake vừa đi vào cell của `enteredArrow` (đúng hướng).
		/// Flip ngay cả 2 arrow nếu chúng là Switching (không phải Fixed).
		/// </summary>
		public void OnSnakeEntered(ArrowSwitchController enteredArrow)
		{
			if (enteredArrow == null) return;

			// Flip arrow mà snake vừa qua
			if (!enteredArrow.IsFixedArrow)
				enteredArrow.InverseDirection();

			// Flip partner ngay lập tức
			ArrowSwitchController partner = (enteredArrow == _arrowA) ? _arrowB : _arrowA;
			if (partner != null && !partner.IsFixedArrow)
				partner.InverseDirection();
		}

		public bool Contains(ArrowSwitchController arrow) =>
			arrow == _arrowA || arrow == _arrowB;
	}
}
