#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: MiscMaths.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


namespace ForestOfChaosLibrary.Maths {
    public class MiscMaths {
        public static bool IsOdd(int value) => (value % 2) != 0;

        public static bool IsEven(int value) => (value % 2) == 0;
    }
}