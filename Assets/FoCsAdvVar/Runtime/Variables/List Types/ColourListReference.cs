#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: ColourListReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaosLists]
    public class ColourListReference: AdvListReference<Colour> { }

    [Serializable]
    public class ColourListVariable: AdvListVariable<Colour, ColourListReference> { }
}