using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
	public sealed class RectVerticalScope: RectLayoutScope
	{
		public RectVerticalScope(int count, Rect rect): base(count, rect) { }

		protected override Rect InitNextRect()
		{
			var lRect = Rect;
			lRect.height = lRect.height / Count;

			return lRect;
		}

		protected override void DoNextRect()
		{
			var nexRect = NextRect;
			nexRect.y += nexRect.height;
			NextRect  =  nexRect;
			++CurrentIndex;
		}

		protected override Rect DoAmountRectCalculations(Rect rect, int amount) => rect.MultiplyHeight(amount);
	}
}
