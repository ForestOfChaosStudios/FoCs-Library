#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: IntListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystemTypeLists]
    [CreateAssetMenu(fileName = "New " + nameof(IntListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(IntListReference), order = 0)]
    public class IntListReference: AdvListReference<int> { }

    [Serializable]
    public class IntListVariable: AdvListVariable<int> { }
}