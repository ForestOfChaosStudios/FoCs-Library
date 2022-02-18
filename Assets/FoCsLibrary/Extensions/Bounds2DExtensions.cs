#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Bounds2DExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Extensions {
    public static class Bounds2DExtensions {
        public static Vector3 GetRandomPosInBounds(this Bounds bounds) =>
                new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
    }
}