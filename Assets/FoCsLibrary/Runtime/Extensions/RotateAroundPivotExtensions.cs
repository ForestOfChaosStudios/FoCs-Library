#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: RotateAroundPivotExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Maths {
    public static class RotateAroundPivotExtensions {
        //Returns the rotated Vector3 using a Quaternion
        public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Quaternion Angle) => (Angle * (Point - Pivot)) + Pivot;

        //Returns the rotated Vector3 using Euler
        public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Vector3 Euler) => RotateAroundPivot(Point, Pivot, Quaternion.Euler(Euler));

        //Rotates the Transform's position using a Quaternion
        public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Quaternion Angle) {
            Me.position = Me.position.RotateAroundPivot(Pivot, Angle);
        }

        //Rotates the Transform's position using Euler
        public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Vector3 Euler) {
            Me.position = Me.position.RotateAroundPivot(Pivot, Quaternion.Euler(Euler));
        }
    }
}