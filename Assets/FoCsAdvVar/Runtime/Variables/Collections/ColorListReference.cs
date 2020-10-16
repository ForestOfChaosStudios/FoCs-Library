#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColorListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnityLists]
    [CreateAssetMenu(fileName = "New " + nameof(ColorListReference), menuName = "ADV Variables/" + nameof(AdvListReference) + "/" + nameof(ColorListReference), order = 0)]
    public class ColorListReference: AdvListReference<Color> { }

    [Serializable]
    public class ColorListVariable: AdvListVariable<Color> { }
}