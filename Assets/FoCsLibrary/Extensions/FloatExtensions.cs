#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FloatExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.Maths.Lerp;

namespace ForestOfChaos.Unity.Extensions {
    public static class FloatExtensions {
        public static bool IsZero(this float f) => f == 0;

        public static bool IsZeroOrNegative(this float f) => f <= 0;

        public static bool IsNegative(this float f) => f < 0;

        public static bool IsZeroOrPositive(this float f) => f >= 0;

        public static bool IsPositive(this float f) => f > 0;

        public static float Abs(this float f) => Math.Abs(f);

        public static float Lerp(this float start, float end, float time, bool clamp = false) => Lerps.Lerp(start, end, time, clamp);

        public static float Clamp(this float f, float min = 0, float max = 1) {
            if (f < min)
                f = min;
            else if (f > max)
                f = max;

            return f;
        }

        public static float Truncate(this float value, int digits) {
            var mult   = Math.Pow(10.0, digits);
            var result = Math.Truncate(mult * value) / mult;

            return (float)result;
        }

        public static int CastToInt(this float f) => (int)(f + 0.5f);

        public static float Remap(this float value, float from1, float to1, float from2, float to2) => (((value - from1) / (to1 - from1)) * (to2 - from2)) + from2;
    }
}