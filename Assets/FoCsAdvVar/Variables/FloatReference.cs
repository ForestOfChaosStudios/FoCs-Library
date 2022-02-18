#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: FloatReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    [CreateAssetMenu(fileName = "New " + nameof(FloatReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(FloatReference), order = 0)]
    public class FloatReference: AdvReference<float> { }

    [Serializable]
    public class FloatVariable: AdvVariable<float> {
        public static implicit operator FloatVariable(float input) {
            var fR = new FloatVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}