#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2IntListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New "                                            + nameof(Vector2IntListReference),
                     menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(Vector2IntListReference),
                     order    = 0)]
    public class Vector2IntListReference: AdvListReference<Vector2Int> { }

    [Serializable]
    public class Vector2IntListVariable: AdvListVariable<Vector2Int> { }
}