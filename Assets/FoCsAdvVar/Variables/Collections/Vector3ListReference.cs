#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector3ListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New " + nameof(Vector3ListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(Vector3ListReference), order = 0)]
    public class Vector3ListReference: AdvListReference<Vector3> { }

    [Serializable]
    public class Vector3ListVariable: AdvListVariable<Vector3> { }
}