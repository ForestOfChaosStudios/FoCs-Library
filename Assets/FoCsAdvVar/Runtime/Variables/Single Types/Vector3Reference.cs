#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3Reference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class Vector3Reference: AdvReference<Vector3> { }

    [Serializable]
    public class Vector3Variable: AdvVariable<Vector3> {
        public static implicit operator Vector3Variable(Vector3 input) {
            var fR = new Vector3Variable {UseLocal = true, Value = input};

            return fR;
        }
    }
}