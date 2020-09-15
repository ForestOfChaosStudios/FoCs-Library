#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3IntListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    public class Vector3IntListReference: AdvListReference<Vector3Int> { }

    [Serializable]
    public class Vector3IntListVariable: AdvListVariable<Vector3Int> { }
}