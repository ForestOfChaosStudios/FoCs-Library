#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: QuaternionListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New "           + nameof(QuaternionListReference),
                     menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(QuaternionListReference),
                     order = 0)]
    public class QuaternionListReference: AdvListReference<Quaternion> { }

    [Serializable]
    public class QuaternionListVariable: AdvListVariable<Quaternion> { }
}