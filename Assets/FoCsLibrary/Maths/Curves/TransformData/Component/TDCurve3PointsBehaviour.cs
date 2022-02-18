#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TDCurve3PointsBehaviour.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 3")]
    public class TDCurve3PointsBehaviour: ITDCurveComponent<TDCurve3Points> {
        private void Reset() {
            Curve = new TDCurve3Points();
        }
    }
}