#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ActionOnDispose.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;

namespace ForestOfChaos.Unity.Utilities {
    public class ActionOnDispose: IDisposable {
        private readonly Action action;

        public ActionOnDispose(Action action) => this.action = action;

        public void Dispose() => action.Trigger();
    }
}