#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2IntReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class Vector2IntReference: AdvReference<Vector2Int> { }

    [Serializable]
    public class Vector2IntVariable: AdvVariable<Vector2Int> {
        public static implicit operator Vector2IntVariable(Vector2Int input) {
            var fR = new Vector2IntVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}