#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: MonoBehaviourRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    [Serializable]
    [AdvFolderNameRunTime]
    [CreateAssetMenu(fileName = "New " + nameof(MonoBehaviourRunTimeRef), menuName = "ADV Variables/" + nameof(RunTimeRef) + "/" + nameof(MonoBehaviourRunTimeRef), order = 0)]
    public class MonoBehaviourRunTimeRef: RunTimeRef<MonoBehaviour> { }
}