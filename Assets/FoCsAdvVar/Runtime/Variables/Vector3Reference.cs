#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3Reference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(Vector3Reference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector3Reference), order = 0)]
    public class Vector3Reference: AdvReference<Vector3> { }

    [Serializable]
    public class Vector3Variable: AdvVariable<Vector3> {
        public static implicit operator Vector3Variable(Vector3 input) {
            var fR = new Vector3Variable {UseLocal = true, Value = input};

            return fR;
        }
    }
}