#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: TDCurve3PointsBehaviour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 3")]
    public class TDCurve3PointsBehaviour: ITDCurveComponent<TDCurve3Points> {
        private void Reset() {
            Curve = new TDCurve3Points();
        }
    }
}