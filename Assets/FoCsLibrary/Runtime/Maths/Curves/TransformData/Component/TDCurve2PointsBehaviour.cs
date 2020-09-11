#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TDCurve2PointsBehaviour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 2")]
    public class TDCurve2PointsBehaviour: ITDCurveComponent<TDCurve2Points> {
        private void Reset() {
            Curve = new TDCurve2Points();
        }
    }
}