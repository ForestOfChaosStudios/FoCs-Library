#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: VectorUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Utilities {
    public static class VectorUtilities {


#region GetPosOnY
#region Extensions
        public static Vector3 GetPosOnY(this Ray ray) => GetPosOnY(0, ray);

        public static Vector3 GetPosOnY(this Ray ray, float yAxis) => GetPosOnYAxis(yAxis, ray);

        public static Vector3 GetPosOnY(this Ray ray, Vector3 yAxis) => GetPosOnYAxis(yAxis.y, ray);
#endregion


        public static Vector3 GetPosOnY(float yAxis, Ray ray) => GetPosOnYAxis(yAxis, ray);

        public static Vector3 GetPosOnY(Vector3 yAxis, Ray ray) => GetPosOnYAxis(yAxis.y, ray);

        public static Vector3 GetPosOnYAxis(float yAxis, Ray ray) {
            var dst = (yAxis - ray.origin.y) / ray.direction.y;

            return ray.origin + (ray.direction * dst);
        }
#endregion


    }
}