#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2IntReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(Vector2IntReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector2IntReference), order = 0)]
    public class Vector2IntReference: AdvReference<Vector2Int> { }

    [Serializable]
    public class Vector2IntVariable: AdvVariable<Vector2Int> {
        public static implicit operator Vector2IntVariable(Vector2Int input) {
            var fR = new Vector2IntVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}