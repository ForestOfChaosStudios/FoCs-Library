#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ITDCurve.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using ForestOfChaos.Unity.Types;

namespace ForestOfChaos.Unity.Maths.Curves {
    public interface ITDCurve {
        List<TransformData> CurvePositions { get; set; }

        bool IsFixedLength { get; }

        bool UseGlobalSpace { get; set; }

        int Length { get; }

        TransformData Lerp(float time);
    }
}