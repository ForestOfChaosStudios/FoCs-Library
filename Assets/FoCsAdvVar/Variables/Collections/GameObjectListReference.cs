#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: GameObjectListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New "           + nameof(GameObjectListReference),
                     menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(GameObjectListReference),
                     order = 0)]
    public class GameObjectListReference: AdvListReference<GameObject> { }

    [Serializable]
    public class GameObjectListVariable: AdvListVariable<GameObject> { }
}