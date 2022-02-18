#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ActionOnDispose.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;

namespace ForestOfChaos.Unity.Utilities {
    public class ActionOnDispose: IDisposable {
        private readonly Action action;

        public ActionOnDispose(Action action) => this.action = action;

        public void Dispose() => action?.Invoke();
    }
}