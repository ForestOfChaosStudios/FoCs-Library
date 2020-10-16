#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: IntReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    [CreateAssetMenu(fileName = "New " + nameof(IntReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(IntReference), order = 0)]
    public class IntReference: AdvReference<int> { }

    [Serializable]
    public class IntVariable: AdvVariable<int> {
        public static implicit operator IntVariable(int input) {
            var fR = new IntVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}