#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: IntReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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
            var fR = new IntVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}