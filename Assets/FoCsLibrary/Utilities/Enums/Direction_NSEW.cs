#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Direction_NSEW.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.Utilities.Enums {
    public enum Direction_NSEW {
        North,
        South,
        East,
        West
    }

    public static class Direction_NSEW_Helper {
        public const Direction_NSEW FIRST = Direction_NSEW.North;
        public const Direction_NSEW LAST  = Direction_NSEW.West;

        public static Direction_NSEW Next(this Direction_NSEW val) {
            switch (val) {
                case LAST: return FIRST;
                default:   return ++val;
            }
        }

        public static Direction_NSEW Previous(this Direction_NSEW val) {
            switch (val) {
                case FIRST: return LAST;
                default:    return --val;
            }
        }
    }
}