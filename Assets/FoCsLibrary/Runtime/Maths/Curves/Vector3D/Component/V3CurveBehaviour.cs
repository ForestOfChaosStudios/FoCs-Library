#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: V3CurveBehaviour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Any Length")]
    public class V3CurveBehaviour: IV3CurveComponent<V3Curve> {
        private void Reset() {
            Curve = new V3Curve();
        }
    }
}