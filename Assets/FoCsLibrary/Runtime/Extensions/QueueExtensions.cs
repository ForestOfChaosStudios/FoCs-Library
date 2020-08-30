#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: QueueExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;

namespace ForestOfChaosLibrary.Extensions {
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