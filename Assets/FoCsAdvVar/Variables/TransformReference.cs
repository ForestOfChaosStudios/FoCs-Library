#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: TransformReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(TransformReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(TransformReference), order = 0)]
    public class TransformReference: AdvReference<Transform> { }

    [Serializable]
    public class TransformVariable: AdvVariable<Transform> {
        public static implicit operator TransformVariable(Transform input) {
            var fR = new TransformVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}