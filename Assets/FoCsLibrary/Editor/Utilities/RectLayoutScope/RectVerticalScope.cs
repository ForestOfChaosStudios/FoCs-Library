#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: RectVerticalScope.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.Utilities {
    public sealed class RectVerticalScope: RectLayoutScope {
        public RectVerticalScope(int count, Rect rect): base(count, rect) { }

        protected override Rect InitNextRect() {
            var lRect = Rect;
            lRect.height = lRect.height / Count;

            return lRect;
        }

        protected override void DoNextRect() {
            var nexRect = NextRect;
            nexRect.y += nexRect.height;
            NextRect  =  nexRect;
            ++CurrentIndex;
        }

        protected override Rect DoGetNextAmount(int amount, Rect retVal) {
            retVal = retVal.Edit(RectEdit.SetHeight(retVal.height * amount));

            return retVal;
        }
    }
}