#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TransformDataLerp.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Lerp {
    public static class TransformDataLerp {
        public static TransformData Lerp(TransformData value1, TransformData value2, float time, bool clamp = false) =>
                Lerp(value1, value2, time, TransformDataLerpSettings.Default, clamp);

        public static TransformData Lerp(TransformData value1, TransformData value2, float time, TransformDataLerpSettings settings, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var output = TransformData.Empty;
            output.Position = DoVector3Lerp(value1.Position, value2.Position, time, settings.UsePosition);
            output.Rotation = DoQuaternionLerp(value1.Rotation, value2.Rotation, time, settings.UsePosition);
            output.Scale    = DoVector3Lerp(value1.Scale, value2.Scale, time, settings.UsePosition);

            return output;
        }

        private static Quaternion DoQuaternionLerp(Quaternion value1, Quaternion value2, float time, TransformDataLerpSettings.ModeSetting settings) {
            Quaternion output;

            switch (settings) {
                case TransformDataLerpSettings.ModeSetting.Use:
                    output = QuaternionLerp.Lerp(value1, value2, time);

                    break;
                case TransformDataLerpSettings.ModeSetting.Left:
                    output = value1;

                    break;
                case TransformDataLerpSettings.ModeSetting.Right:
                    output = value2;

                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            return output;
        }

        private static Vector3 DoVector3Lerp(Vector3 value1, Vector3 value2, float time, TransformDataLerpSettings.ModeSetting settings) {
            Vector3 output;

            switch (settings) {
                case TransformDataLerpSettings.ModeSetting.Use:
                    output = Vector3Lerp.Lerp(value1, value2, time);

                    break;
                case TransformDataLerpSettings.ModeSetting.Left:
                    output = value1;

                    break;
                case TransformDataLerpSettings.ModeSetting.Right:
                    output = value2;

                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            return output;
        }

        public static TransformData Lerp(TransformData value1, TransformData value2, TransformData value3, float time, bool clamp = false) =>
                Lerp(value1, value2, value3, time, TransformDataLerpSettings.Default, clamp);

        public static TransformData Lerp(TransformData value1, TransformData value2, TransformData value3, float time, TransformDataLerpSettings settings, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var one = Lerp(value1, value2, time);
            var two = Lerp(value2, value3, time);

            return Lerp(one, two, time);
        }

        public static TransformData Lerp(TransformData value1, TransformData value2, TransformData value3, TransformData value4, float time, bool clamp = false) =>
                Lerp(value1, value2, value3, value4, time, TransformDataLerpSettings.Default, clamp);

        public static TransformData Lerp(TransformData             value1,
                                         TransformData             value2,
                                         TransformData             value3,
                                         TransformData             value4,
                                         float                     time,
                                         TransformDataLerpSettings settings,
                                         bool                      clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne   = Lerp(value1, value2, time);
            var posTwo   = Lerp(value2, value3, time);
            var posThree = Lerp(value3, value4, time);
            posOne = Lerp(posOne, posTwo,   time);
            posTwo = Lerp(posOne, posThree, time);

            return Lerp(posOne, posTwo, time);
        }

        public static TransformData Lerp(List<TransformData> curve, float time, bool clamp = false) => Lerp(curve, time, TransformDataLerpSettings.Default, clamp);

        public static TransformData Lerp(List<TransformData> curve, float time, TransformDataLerpSettings settings, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var count = curve.Count;

            switch (count) {
                case 0: return new TransformData();
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

        public static TransformData Lerp(TransformData[] curve, float time, bool clamp = false) => Lerp(curve, time, TransformDataLerpSettings.Default, clamp);

        public static TransformData Lerp(TransformData[] curve, float time, TransformDataLerpSettings settings, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var count = curve.Length;

            switch (count) {
                case 0: return new TransformData();
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