#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: FloatReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    public class FloatReference: AdvReference<float> { }

    [Serializable]
    public class FloatVariable: AdvVariable<float, FloatReference> {
        public static implicit operator FloatVariable(float input) {
            var fR = new FloatVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}