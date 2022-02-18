#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: CameraRunTimeRef.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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