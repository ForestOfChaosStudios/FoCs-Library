﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    public class Vector3IReference: AdvReference<Vector3I> { }

    [Serializable]
    public class Vector3IVariable: AdvVariable<Vector3I> {
        public static implicit operator Vector3IVariable(Vector3I input) {
            var fR = new Vector3IVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}