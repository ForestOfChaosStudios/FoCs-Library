#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2ListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New " + nameof(Vector2ListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(Vector2ListReference), order = 0)]
    public class Vector2ListReference: AdvListReference<Vector2> { }

    [Serializable]
    public class Vector2ListVariable: AdvListVariable<Vector2> { }
}