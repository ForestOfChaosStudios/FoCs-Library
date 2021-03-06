﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: VectorAngles.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Maths {
    public static class VectorAngles {
        public static Vector3 ClampAngle(Vector3 angle, float min, float max) =>
                new Vector3(ClampAngle(angle.x, min, max), ClampAngle(angle.y, min, max), ClampAngle(angle.z, min, max));

        ///Normalize angles to a range from -180 to 180 an then clamp the angle with min and max.
        public static float ClampAngle(float angle, float min, float max) {
            angle = NormalizeAngle(angle);

            if (angle > 180)
                angle -= 360;
            else if (angle < -180)
                angle += 360;

            min = NormalizeAngle(min);

            if (min > 180)
                min -= 360;
            else if (min < -180)
                min += 360;

            max = NormalizeAngle(max);

            if (max > 180)
                max -= 360;
            else if (max < -180)
                max += 360;

            // Aim is, convert angles to -180 until 180.
            return Mathf.Clamp(angle, min, max);
        }

        /// If angles over 360 or under 360 degree, then normalize them.
        public static float NormalizeAngle(float angle) {
            while (angle > 360)
                angle -= 360;

            while (angle < 0)
                angle += 360;

            return angle;
        }
    }
}