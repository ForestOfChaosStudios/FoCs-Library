#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: GridUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
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