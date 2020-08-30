#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: ByteReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    public class ByteReference: AdvReference<byte> { }

    [Serializable]
    public class ByteVariable: AdvVariable<byte, ByteReference> {
        public static implicit operator ByteVariable(byte input) {
            var fR = new ByteVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}