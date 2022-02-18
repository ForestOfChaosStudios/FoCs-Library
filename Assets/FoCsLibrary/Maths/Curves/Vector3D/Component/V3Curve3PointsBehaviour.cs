#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: V3Curve3PointsBehaviour.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Length 2")]
    public class V3Curve3PointsBehaviour: IV3CurveComponent<V3Curve3Points> {
        private void Reset() {
            Curve = new V3Curve3Points();
        }
    }
}