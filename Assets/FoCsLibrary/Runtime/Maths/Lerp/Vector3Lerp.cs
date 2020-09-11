#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Vector3Lerp.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Lerp {
    public static class Vector3Lerp {
        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            return value1 + ((value2 - value1) * time);
        }

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, Vector3 value3, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne = Lerp(value1, value2, time);
            var posTwo = Lerp(value2, value3, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne   = Lerp(value1, value2, time);
            var posTwo   = Lerp(value2, value3, time);
            var posThree = Lerp(value3, value4, time);
            posOne = Lerp(posOne, posTwo,   time);
            posTwo = Lerp(posOne, posThree, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, Vector2 value3, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne = Lerp(value1, value2, time);
            var posTwo = Lerp(value2, value3, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Vector3 Lerp(List<Vector3> curve, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var count = curve.Count;

            switch (count) {
                case 0: return Vector3.zero;
                case 1: return curve[0];
                case 2: return Lerp(curve[0], curve[1], time);
                case 3: return Lerp(curve[0], curve[1], curve[2], time);
                case 4: return Lerp(curve[0], curve[1], curve[2], curve[3],                       time);
                case 5: return Lerp(curve[0], curve[1], curve[2], Lerp(curve[3], curve[4], time), time);
            }

            //FROM HERE IS IS SAFE
            //For there to be at least 5 hard coded positions
            var posOne   = Lerp(curve[0], curve[1], time);
            var posTwo   = Lerp(curve[1], curve[2], time);
            var posThree = Lerp(curve[2], curve[3], time);

            for (var i = 4; i < count - 1; i++) {
                posOne   = Lerp(posOne,   posTwo,       time);
                posTwo   = Lerp(posTwo,   posThree,     time);
                posThree = Lerp(curve[i], curve[i + 1], time);
            }

            posOne = Lerp(posOne, posTwo,   time);
            posTwo = Lerp(posTwo, posThree, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Vector3 Lerp(Vector3[] curve, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var count = curve.Length;

            switch (count) {
                case 0: return Vector3.zero;
                case 1: return curve[0];
                case 2: return Lerp(curve[0], curve[1], time);
                case 3: return Lerp(curve[0], curve[1], curve[2], time);
                case 4: return Lerp(curve[0], curve[1], curve[2], curve[3],                       time);
                case 5: return Lerp(curve[0], curve[1], curve[2], Lerp(curve[3], curve[4], time), time);
            }

            //FROM HERE IS IS SAFE
            //For there to be at least 5 hard coded positions
            var posOne   = Lerp(curve[0], curve[1], time);
            var posTwo   = Lerp(curve[1], curve[2], time);
            var posThree = Lerp(curve[2], curve[3], time);

            for (var i = 4; i < count - 1; i++) {
                posOne   = Lerp(posOne,   posTwo,       time);
                posTwo   = Lerp(posTwo,   posThree,     time);
                posThree = Lerp(curve[i], curve[i + 1], time);
            }

            posOne = Lerp(posOne, posTwo,   time);
            posTwo = Lerp(posTwo, posThree, time);

            return Lerp(posOne, posTwo, time);
        }
    }
}