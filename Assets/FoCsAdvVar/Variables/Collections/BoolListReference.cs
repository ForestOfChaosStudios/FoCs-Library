#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BoolListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystemTypeLists]
    [CreateAssetMenu(fileName = "New " + nameof(BoolListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(BoolListReference), order = 0)]
    public class BoolListReference: AdvListReference<bool> { }

    [Serializable]
    public class BoolListVariable: AdvListVariable<bool> { }
}