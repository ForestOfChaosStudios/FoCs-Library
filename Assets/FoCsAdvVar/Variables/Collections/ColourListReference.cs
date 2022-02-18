#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColourListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaosLists]
    [CreateAssetMenu(fileName = "New " + nameof(ColourListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(ColourListReference), order = 0)]
    public class ColourListReference: AdvListReference<Colour> { }

    [Serializable]
    public class ColourListVariable: AdvListVariable<Colour> { }
}