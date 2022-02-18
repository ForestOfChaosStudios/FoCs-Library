#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Lerp.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;

namespace ForestOfChaos.Unity.Maths.Lerp {
    public static class Lerps {
        public static float Lerp(float value1, float value2, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            return value1 + ((value2 - value1) * time);
        }

        public static float Lerp(float value1, float value2, float value3, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne = Lerp(value1, value2, time);
            var posTwo = Lerp(value2, value3, time);

            return posOne + ((posTwo - posOne) * time);
        }

        public static float Lerp(List<float> curve, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            switch (curve.Count) {
                case 0: return 0;
                case 1: return curve[0];
                case 2: return Lerp(curve[0], curve[1], time);
                case 3: return Lerp(curve[0], curve[1], curve[2],                                             time);
                case 4: return Lerp(curve[0], curve[1], Lerp(curve[2], curve[3],                       time), time);
                case 5: return Lerp(curve[0], curve[1], Lerp(curve[2], Lerp(curve[3], curve[4], time), time), time);
            }

            //FROM HERE IS IS SAFE
            //For there to be at least 5 hard coded positions
            var count    = curve.Count;
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

        public static float Lerp(int value1, int value2, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            return value1 + ((value2 - value1) * time);
        }

        public static float Lerp(int value1, int value2, int value3, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            var posOne = Lerp(value1, value2, time);
            var posTwo = Lerp(value2, value3, time);

            return posOne + ((posTwo - posOne) * time);
        }

        public static float Lerp(List<int> curve, float time, bool clamp = false) {
            if (clamp)
                time = time.Clamp();

            switch (curve.Count) {
                case 0: return 0;
                case 1: return curve[0];
                case 2: return Lerp(curve[0], curve[1], time);
                case 3: return Lerp(curve[0], curve[1], curve[2],                                             time);
                case 4: return Lerp(curve[0], curve[1], Lerp(curve[2], curve[3],                       time), time);
                case 5: return Lerp(curve[0], curve[1], Lerp(curve[2], Lerp(curve[3], curve[4], time), time), time);
            }

            //FROM HERE IS IS SAFE
            //For there to be at least 5 hard coded positions
            var count    = curve.Count;
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