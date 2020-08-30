#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: GridUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Types;
using ForestOfChaosLibrary.Utilities;
using UnityEngine;

namespace ForestOfChaosLibrary.Grid {
    public static class GridUtilities {
        public static GridPosition GetGridPosition(this Ray ray) => GetGridPosition(ray.GetPosOnY());

        public static GridPosition GetGridPosition(this Vector3 v3) => new Vector2I(v3.x.CastToInt(), v3.z.CastToInt());
    }
}