#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RandomStrings.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.Maths;

namespace ForestOfChaos.Unity.Maths.Random {
    public static class RandomStrings {
        public const string ALPHA           = "abcdefghijklmnopqrstuvwxyz";
        public const string NUMERIC         = "1234567890";
        public const string SYMBOLS         = "!@#$%^&*()-_=+`~,<.>/?;:'";
        public const string ALL_CHARS       = ALPHA + NUMERIC + SYMBOLS;
        public const string ALPHA_SYMBOLS   = ALPHA           + SYMBOLS;
        public const string NUMERIC_SYMBOLS = NUMERIC         + SYMBOLS;

        public static string GetRandomString(int length) => GetRandomString(ALL_CHARS, length, DateTime.UtcNow.Millisecond);

        public static string GetRandomString(int length, int seed) => GetRandomString(ALL_CHARS, length, seed);

        public static string GetRandomString(string characters, int length, int seed) {
            var s    = "";
            var rand = new System.Random(seed);

            for (var i = 0; i < length; i++) {
                if (MiscMaths.IsOdd(i))
                    s += characters[rand.Next(characters.Length)];
                else
                    s += characters[rand.Next(characters.Length)];
            }

            return s;
        }

        public static string GetRandomAltString(int length) => GetRandomAltString(length, DateTime.UtcNow.Millisecond);

        public static string GetRandomAltString(int length, int seed) {
            var s    = "";
            var rand = new System.Random(seed);

            for (var i = 0; i < length; i++) {
                if (MiscMaths.IsOdd(i))
                    s += NUMERIC[rand.Next(NUMERIC.Length)];
                else
                    s += ALPHA[rand.Next(ALPHA.Length)];
            }

            return s;
        }
    }
}