#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Direction_UPLRFB.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Utilities.Enums {
    public enum Direction_UDLRFB {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }

    public static class Direction_UDLRFB_Helpers {
        public const Direction_UDLRFB FIRST = Direction_UDLRFB.Up;
        public const Direction_UDLRFB LAST  = Direction_UDLRFB.Backward;

        public static Direction_UDLRFB Next(this Direction_UDLRFB val) {
            switch (val) {
                case LAST: return FIRST;
                default:   return ++val;
            }
        }

        public static Direction_UDLRFB Previous(this Direction_UDLRFB val) {
            switch (val) {
                case FIRST: return LAST;
                default:    return --val;
            }
        }

        public static Vector3 GetDirection(this Direction_UDLRFB val) {
            switch (val) {
                case Direction_UDLRFB.Forward:  return Vector3.forward;
                case Direction_UDLRFB.Backward: return Vector3.back;
                case Direction_UDLRFB.Left:     return Vector3.left;
                case Direction_UDLRFB.Right:    return Vector3.right;
                case Direction_UDLRFB.Up:       return Vector3.up;
                case Direction_UDLRFB.Down:     return Vector3.down;
            }

            return Vector3.zero;
        }

        public static Vector3 GetDirection(this Direction_UDLRFB val, Transform transform) {
            GetDirection(val, transform, out var dir);

            return dir;
        }

        public static Vector3 GetDirection(this Transform transform, Direction_UDLRFB val) {
            GetDirection(val, transform, out var dir);

            return dir;
        }

        private static void GetDirection(Direction_UDLRFB val, Transform transform, out Vector3 dir) {
            dir = Vector3.zero;

            switch (val) {
                case Direction_UDLRFB.Forward:
                    dir = transform.forward;

                    return;
                case Direction_UDLRFB.Backward:
                    dir = -transform.forward;

                    return;
                case Direction_UDLRFB.Left:
                    dir = -transform.right;

                    return;
                case Direction_UDLRFB.Right:
                    dir = transform.right;

                    return;
                case Direction_UDLRFB.Up:
                    dir = transform.up;

                    return;
                case Direction_UDLRFB.Down:
                    dir = -transform.up;

                    return;
            }
        }

        public static Vector3 EulerAngles(this Direction_UDLRFB val) {
            switch (val) {
                case Direction_UDLRFB.Forward:  return Vector3.zero;
                case Direction_UDLRFB.Backward: return Vector3.up    * 180;
                case Direction_UDLRFB.Up:       return Vector3.left  * 90;
                case Direction_UDLRFB.Down:     return Vector3.right * 90;
                case Direction_UDLRFB.Left:     return Vector3.down  * 90;
                case Direction_UDLRFB.Right:    return Vector3.up    * 90;
                default:                        return Vector3.zero;
            }
        }

        public static void Rotate(this Transform transform, Direction_UDLRFB dir) => transform.Rotate(dir.EulerAngles());
    }
}