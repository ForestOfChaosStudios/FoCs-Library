#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector4IReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    public class Vector4IReference: AdvReference<Vector4I> { }

    [Serializable]
    public class Vector4IVariable: AdvVariable<Vector4I, Vector4IReference> {
        public static implicit operator Vector4IVariable(Vector4I input) {
            var fR = new Vector4IVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}