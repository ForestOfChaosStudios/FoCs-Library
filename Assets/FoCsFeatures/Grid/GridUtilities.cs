#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Features.Grid
//       File: GridUtilities.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Types;
using ForestOfChaos.Unity.Utilities;
using UnityEngine;

namespace ForestOfChaos.Unity.Features.Grid {
    public static class GridUtilities {
        public static GridPosition GetGridPosition(this Ray ray) => GetGridPosition(ray.GetPosOnY());

        public static GridPosition GetGridPosition(this Vector3 v3) => new Vector2I(v3.x.CastToInt(), v3.z.CastToInt());
    }
}