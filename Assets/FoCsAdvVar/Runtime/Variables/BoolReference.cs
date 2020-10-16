#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BoolReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    [CreateAssetMenu(fileName = "New " + nameof(BoolReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(BoolReference), order = 0)]
    public class BoolReference: AdvReference<bool> { }

    [Serializable]
    public class BoolVariable: AdvVariable<bool> {
        public static implicit operator BoolVariable(bool input) {
            var fR = new BoolVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}