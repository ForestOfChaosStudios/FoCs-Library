#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: TDCurvePropertyDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Maths.Curves;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.Maths.Curves {
    public class TDCurvePropertyDrawer: CurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve))]
    public class TDCurveArrayPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve2Points))]
    public class TDCurve2PointsPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve3Points))]
    public class TDCurve3PointsPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve4Points))]
    public class TDCurve4PointsPropertyDrawer: TDCurvePropertyDrawer { }
}