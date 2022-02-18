#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: QueueExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;

namespace ForestOfChaos.Unity.Extensions {
    public static class QueueExtensions {
        public static T GetNextItemAndReAddItToTheEnd<T>(this Queue<T> queue) {
            //Get first
            var item = queue.Dequeue();
            //Re add
            queue.Enqueue(item);

            return item;
        }
    }
}