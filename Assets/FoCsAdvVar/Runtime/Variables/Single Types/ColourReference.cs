#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColourReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    public class ColourReference: AdvReference<Colour> { }

    [Serializable]
    public class ColourVariable: AdvVariable<Colour, ColourReference> {
        public static implicit operator ColourVariable(Colour input) {
            var fR = new ColourVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}