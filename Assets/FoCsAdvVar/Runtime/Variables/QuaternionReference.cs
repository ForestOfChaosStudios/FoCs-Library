#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: QuaternionReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(QuaternionReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(QuaternionReference), order = 0)]
    public class QuaternionReference: AdvReference<Quaternion> { }

    [Serializable]
    public class QuaternionVariable: AdvVariable<Quaternion> {
        public static implicit operator QuaternionVariable(Quaternion input) {
            var fR = new QuaternionVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}