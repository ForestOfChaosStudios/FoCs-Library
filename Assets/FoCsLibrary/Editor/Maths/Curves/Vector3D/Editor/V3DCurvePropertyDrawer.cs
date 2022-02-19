#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: V3DCurvePropertyDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Maths.Curves;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.Maths.Curves {
    public class V3DCurvePropertyDrawer: CurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(V3Curve))]
    public class V3DCurveArrayPropertyDrawer: V3DCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(V3Curve3Points))]
    public class V3DCurve3PointsPropertyDrawer: V3DCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(V3Curve4Points))]
    public class V3DCurve4PointsPropertyDrawer: V3DCurvePropertyDrawer { }
}