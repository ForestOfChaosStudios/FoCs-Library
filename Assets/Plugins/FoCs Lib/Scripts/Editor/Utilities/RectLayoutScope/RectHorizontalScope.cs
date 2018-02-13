﻿using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
	public class RectHorizontalScope: RectLayoutScope
	{
		public RectHorizontalScope(int count, Rect rect)
			: base(count, rect)
		{ }

		protected override Rect InitNextRect()
		{
			var lRect = Rect;
			lRect.width = lRect.width / Count;
			return lRect;
		}

		protected override void DoNextRect()
		{
			var nexRect = NextRect;
			nexRect.x += nexRect.width;
			NextRect = nexRect;
			++CurrentIndex;
		}

		protected override Rect DoAmountRectCalculations(Rect rect, int amount) => rect.MultiplyWidth(amount);
	}
}