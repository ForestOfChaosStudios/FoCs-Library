#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: Direction_LR.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Utilities.Enums {
    public enum Direction_LR {
        Left,
        Right
    }

    public static class Direction_LR_Helpers {
        public const Direction_LR FIRST = Direction_LR.Left;
        public const Direction_LR LAST  = Direction_LR.Right;

        public static Direction_LR Next(this Direction_LR val) {
            switch (val) {
                case LAST: return FIRST;
                default:   return ++val;
            }
        }

        public static Direction_LR Previous(this Direction_LR val) {
            switch (val) {
                case FIRST: return LAST;
                default:    return --val;
            }
        }

        public static Vector3 EulerAngles(this Direction_LR val) {
            switch (val) {
                case Direction_LR.Left:  return Vector3.down * 90;
                case Direction_LR.Right: return Vector3.up   * 90;
                default:                 return Vector3.zero;
            }
        }

        public static void Rotate(this Transform transform, Direction_LR dir) {
            transform.Rotate(dir.EulerAngles());
        }
    }
}