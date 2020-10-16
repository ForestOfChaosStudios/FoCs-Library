#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: FloatListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystemTypeLists]
    [CreateAssetMenu(fileName = "New " + nameof(FloatListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(FloatListReference), order = 0)]
    public class FloatListReference: AdvListReference<float> { }

    [Serializable]
    public class FloatListVariable: AdvListVariable<float> { }
}