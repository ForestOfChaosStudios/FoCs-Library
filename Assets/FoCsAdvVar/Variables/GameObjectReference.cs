#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: GameObjectReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(GameObjectReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(GameObjectReference), order = 0)]
    public class GameObjectReference: AdvReference<GameObject> { }

    [Serializable]
    public class GameObjectVariable: AdvVariable<GameObject> {
        public static implicit operator GameObjectVariable(GameObject input) {
            var fR = new GameObjectVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}