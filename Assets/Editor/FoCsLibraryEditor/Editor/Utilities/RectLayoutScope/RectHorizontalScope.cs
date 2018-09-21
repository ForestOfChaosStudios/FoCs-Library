using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.Utilities
{
	public sealed class RectHorizontalScope: RectLayoutScope
	{
		public RectHorizontalScope(int count, Rect rect): base(count, rect) { }

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
			NextRect  =  nexRect;
			++CurrentIndex;
		}

		protected override Rect DoGetNextAmount(int amount, Rect retVal)
		{
			retVal = retVal.Edit(RectEdit.SetWidth(retVal.width * amount));

			return retVal;
		}
	}
}
