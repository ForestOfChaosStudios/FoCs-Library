#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IntReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class Vector3IntReference: AdvReference<Vector3Int> { }

    [Serializable]
    public class Vector3IntVariable: AdvVariable<Vector3Int, Vector3IntReference> {
        public static implicit operator Vector3IntVariable(Vector3Int input) {
            var fR = new Vector3IntVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}