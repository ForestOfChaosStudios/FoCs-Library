#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ActionExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;

namespace ForestOfChaos.Unity.Extensions {
    public static class ActionExtensions {
        public static void Trigger(this Action action) => action?.Invoke();

        public static void Trigger<TA>(this Action<TA> action, TA valueA) => action?.Invoke(valueA);

        public static void Trigger<TA, TB>(this Action<TA, TB> action, TA valueA, TB valueB) => action?.Invoke(valueA, valueB);

        public static void Trigger<TA, TB, TC>(this Action<TA, TB, TC> action, TA valueA, TB valueB, TC valueC) => action?.Invoke(valueA, valueB, valueC);

        public static void Trigger<TA, TB, TC, TD>(this Action<TA, TB, TC, TD> action, TA valueA, TB valueB, TC valueC, TD valueD) =>
                action?.Invoke(valueA, valueB, valueC, valueD);
    }
}