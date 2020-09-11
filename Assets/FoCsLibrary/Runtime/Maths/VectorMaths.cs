#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: VectorMaths.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Maths {
    public static class VectorMaths {
        public const float ROTATION_MAX = 360f;

        public static Vector3 GetVectorDirection(Vector3 vA, Vector3 vB, bool Normalized = true) {
            var output = vA - vB;

            if (Normalized)
                output.Normalize();

            return output;
        }

        public static float ClampAngle(this float angle, float min, float max) {
            if (angle < -ROTATION_MAX)
                angle += ROTATION_MAX;

            if (angle > ROTATION_MAX)
                angle -= ROTATION_MAX;

            return Mathf.Clamp(angle, min, max);
        }

        public static float ClampAngle(this float angle) {
            if (angle < -ROTATION_MAX)
                angle += ROTATION_MAX * 2;

            if (angle > ROTATION_MAX)
                angle -= ROTATION_MAX * 2;

            return angle;
        }
    }
}