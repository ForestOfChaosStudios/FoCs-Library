#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: IntReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    public class IntReference: AdvReference<int> { }

    [Serializable]
    public class IntVariable: AdvVariable<int, IntReference> {
        public static implicit operator IntVariable(int input) {
            var fR = new IntVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}