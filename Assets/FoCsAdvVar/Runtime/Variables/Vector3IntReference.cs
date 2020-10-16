#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IntReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(Vector3IntReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector3IntReference), order = 0)]
    public class Vector3IntReference: AdvReference<Vector3Int> { }

    [Serializable]
    public class Vector3IntVariable: AdvVariable<Vector3Int> {
        public static implicit operator Vector3IntVariable(Vector3Int input) {
            var fR = new Vector3IntVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}