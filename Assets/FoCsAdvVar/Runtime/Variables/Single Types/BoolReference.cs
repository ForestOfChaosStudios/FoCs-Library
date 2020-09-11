#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BoolReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    public class BoolReference: AdvReference<bool> { }

    [Serializable]
    public class BoolVariable: AdvVariable<bool, BoolReference> {
        public static implicit operator BoolVariable(bool input) {
            var fR = new BoolVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}