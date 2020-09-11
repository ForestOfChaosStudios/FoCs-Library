#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Direction_FB.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Utilities.Enums {
    public enum Direction_FB {
        Forward,
        Backward
    }

    public static class Direction_FB_Helpers {
        public const Direction_FB FIRST = Direction_FB.Forward;
        public const Direction_FB LAST  = Direction_FB.Backward;

        public static Direction_FB Next(this Direction_FB val) {
            switch (val) {
                case LAST: return FIRST;
                default:   return ++val;
            }
        }

        public static Direction_FB Previous(this Direction_FB val) {
            switch (val) {
                case FIRST: return LAST;
                default:    return --val;
            }
        }

        public static Vector3 EulerAngles(this Direction_FB val) {
            switch (val) {
                case Direction_FB.Forward:  return Vector3.left  * 90;
                case Direction_FB.Backward: return Vector3.right * 90;
                default:                    return Vector3.zero;
            }
        }

        public static void Rotate(this Transform transform, Direction_FB dir) {
            transform.Rotate(dir.EulerAngles());
        }
    }
}