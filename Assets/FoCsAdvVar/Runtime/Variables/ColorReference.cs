#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColorReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(ColorReference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(ColorReference), order = 0)]
    public class ColorReference: AdvReference<Color> { }

    [Serializable]
    public class ColorVariable: AdvVariable<Color> {
        public static implicit operator ColorVariable(Color input) {
            var fR = new ColorVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}