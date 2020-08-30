#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: QuaternionLerp.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Lerp {
    public static class QuaternionLerp {
        public static Quaternion Lerp(Quaternion value1, Quaternion value2, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            if (value1 == value2)
                return value1;

            return Quaternion.Lerp(value1, value2, time);
        }

        public static Quaternion Lerp(Quaternion value1, Quaternion value2, Quaternion value3, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne = Lerp(value1, value2, time);
            var posTwo = Lerp(value2, value3, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Quaternion Lerp(Quaternion value1, Quaternion value2, Quaternion value3, Quaternion value4, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne   = Lerp(value1, value2, time);
            var posTwo   = Lerp(value2, value3, time);
            var posThree = Lerp(value3, value4, time);
            posOne = Lerp(posOne, posTwo,   time);
            posTwo = Lerp(posOne, posThree, time);

            return Lerp(posOne, posTwo, time);
        }

        public static Quaternion Lerp(List<Quaternion> curve, float time, bool clamp = false) => Lerp(curve.ToArray(), time, clamp);

        public static Quaternion Lerp(Quaternion[] curve, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var count = curve.Length;

            switch (count) {
                case 0: return Quaternion.identity;
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