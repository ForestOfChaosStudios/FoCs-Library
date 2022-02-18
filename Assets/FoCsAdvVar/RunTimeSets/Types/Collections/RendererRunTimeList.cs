#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RendererRunTimeList.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Collections {
    [Serializable]
    [AdvFolderNameRunTime]
    [CreateAssetMenu(fileName = "New " + nameof(RendererRunTimeList), menuName = "ADV Variables/" + nameof(RunTimeList) + "/" + nameof(RendererRunTimeList), order = 0)]
    public class RendererRunTimeList: RunTimeList<Renderer> { }
}