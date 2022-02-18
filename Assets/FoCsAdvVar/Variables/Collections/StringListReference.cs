#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: StringListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystemTypeLists]
    [CreateAssetMenu(fileName = "New " + nameof(StringListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(StringListReference), order = 0)]
    public class StringListReference: AdvListReference<string> { }

    [Serializable]
    public class StringListVariable: AdvListVariable<string> { }
}