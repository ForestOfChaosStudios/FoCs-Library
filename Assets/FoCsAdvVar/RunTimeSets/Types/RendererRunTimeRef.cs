#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RendererRunTimeRef.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    [Serializable]
    [AdvFolderNameRunTime]
    [CreateAssetMenu(fileName = "New " + nameof(RendererRunTimeRef), menuName = "ADV Variables/" + nameof(RunTimeRef) + "/" + nameof(RendererRunTimeRef), order = 0)]
    public class RendererRunTimeRef: RunTimeRef<Renderer> { }
}