#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: CameraRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:08 PM
#endregion

using System;
using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    [Serializable]
    [AdvFolderNameRunTime]
    [CreateAssetMenu(fileName = "New " + nameof(CameraRunTimeRef), menuName = "ADV Variables/" + nameof(RunTimeRef) + "/" + nameof(CameraRunTimeRef), order = 0)]
    public class CameraRunTimeRef: RunTimeRef<UCamera> { }
}