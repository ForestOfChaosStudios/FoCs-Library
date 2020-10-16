#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaosLists]
    [CreateAssetMenu(fileName = "New " + nameof(Vector3IListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(Vector3IListReference), order = 0)]
    public class Vector3IListReference: AdvListReference<Vector3I> { }

    [Serializable]
    public class Vector3IListVariable: AdvListVariable<Vector3I> { }
}