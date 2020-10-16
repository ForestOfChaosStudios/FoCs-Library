#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2IReference.cs
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
    [CreateAssetMenu(fileName = "New " + nameof(AnimatorKeyReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector2IReference), order = 0)]
    public class Vector2IReference: AdvReference<Vector2I> { }

    [Serializable]
    public class Vector2IVariable: AdvVariable<Vector2I> {
        public static implicit operator Vector2IVariable(Vector2I input) {
            var fR = new Vector2IVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}