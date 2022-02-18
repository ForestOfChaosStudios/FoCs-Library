#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector4IReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    [CreateAssetMenu(fileName = "New " + nameof(Vector4IReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector4IReference), order = 0)]
    public class Vector4IReference: AdvReference<Vector4I> { }

    [Serializable]
    public class Vector4IVariable: AdvVariable<Vector4I> {
        public static implicit operator Vector4IVariable(Vector4I input) {
            var fR = new Vector4IVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}