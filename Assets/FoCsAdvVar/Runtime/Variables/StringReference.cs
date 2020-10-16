#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: StringReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    [CreateAssetMenu(fileName = "New " + nameof(StringReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(StringReference), order = 0)]
    public class StringReference: AdvReference<string> { }

    [Serializable]
    public class StringVariable: AdvVariable<string> {
        public static implicit operator StringVariable(string input) {
            var fR = new StringVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}