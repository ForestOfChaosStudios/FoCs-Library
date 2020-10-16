#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    [CreateAssetMenu(fileName = "New " + nameof(Vector3IReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector3IReference), order = 0)]
    public class Vector3IReference: AdvReference<Vector3I> { }

    [Serializable]
    public class Vector3IVariable: AdvVariable<Vector3I> {
        public static implicit operator Vector3IVariable(Vector3I input) {
            var fR = new Vector3IVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}