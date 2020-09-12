#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector4Reference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class Vector4Reference: AdvReference<Vector4> { }

    [Serializable]
    public class Vector4Variable: AdvVariable<Vector4> {
        public static implicit operator Vector4Variable(Vector4 input) {
            var fR = new Vector4Variable {UseLocal = true, Value = input};

            return fR;
        }
    }
}