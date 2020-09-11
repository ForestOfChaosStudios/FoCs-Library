#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: MiscMaths.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


namespace ForestOfChaos.Unity.Maths {
    public class MiscMaths {
        public static bool IsOdd(int value) => (value % 2) != 0;

        public static bool IsEven(int value) => (value % 2) == 0;
    }
}