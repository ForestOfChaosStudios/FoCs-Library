#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: V3CurveBehaviour.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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