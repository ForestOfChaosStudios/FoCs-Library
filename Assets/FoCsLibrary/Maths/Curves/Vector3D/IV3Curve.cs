#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: IV3Curve.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves {
    public interface IV3Curve {
        List<Vector3> CurvePositions { get; set; }

        bool IsFixedLength { get; }

        bool UseGlobalSpace { get; set; }

        int Length { get; }

        Vector3 Lerp(float time);
    }
}