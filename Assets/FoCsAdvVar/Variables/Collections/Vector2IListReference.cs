#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2IListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaosLists]
    [CreateAssetMenu(fileName = "New " + nameof(Vector2IListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(Vector2IListReference), order = 0)]
    public class Vector2IListReference: AdvListReference<Vector2I> { }

    [Serializable]
    public class Vector2IListVariable: AdvListVariable<Vector2I> { }
}