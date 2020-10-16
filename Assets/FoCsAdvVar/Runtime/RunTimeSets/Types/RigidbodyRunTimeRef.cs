#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RigidbodyRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    [Serializable]
    [AdvFolderNameRunTime]
    [CreateAssetMenu(fileName = "New " + nameof(RigidbodyRunTimeRef), menuName = "ADV Variables/" + nameof(RunTimeRef) + "/" + nameof(RigidbodyRunTimeRef), order = 0)]
    public class RigidbodyRunTimeRef: RunTimeRef<Rigidbody> { }
}