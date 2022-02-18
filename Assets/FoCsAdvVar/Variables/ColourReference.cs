#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColourReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    [CreateAssetMenu(fileName = "New " + nameof(ColourReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(ColourReference), order = 0)]
    public class ColourReference: AdvReference<Colour> { }

    [Serializable]
    public class ColourVariable: AdvVariable<Colour> {
        public static implicit operator ColourVariable(Colour input) {
            var fR = new ColourVariable { UseLocal = true, Value = input };

            return fR;
        }
    }
}