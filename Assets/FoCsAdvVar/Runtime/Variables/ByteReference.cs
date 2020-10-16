#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ByteReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    [CreateAssetMenu(fileName = "New " + nameof(ByteReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(ByteReference), order = 0)]
    public class ByteReference: AdvReference<byte> { }

    [Serializable]
    public class ByteVariable: AdvVariable<byte> {
        public static implicit operator ByteVariable(byte input) {
            var fR = new ByteVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}