#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: MiscMaths.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.Maths {
    public class MiscMaths {
        public static bool IsOdd(int value) => (value % 2) != 0;

        public static bool IsEven(int value) => (value % 2) == 0;
    }
}