#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: V3CurveBehaviour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Any Length")]
    public class V3CurveBehaviour: IV3CurveComponent<V3Curve> {
        private void Reset() {
            Curve = new V3Curve();
        }
    }
}