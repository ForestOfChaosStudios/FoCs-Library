#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: V3Curve4PointsBehaviour.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Length 4")]
    public class V3Curve4PointsBehaviour: IV3CurveComponent<V3Curve4Points> {
        private void Reset() {
            Curve = new V3Curve4Points();
        }
    }
}