#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: ColorReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class ColorReference: AdvReference<Color> { }

    [Serializable]
    public class ColorVariable: AdvVariable<Color> {
        public static implicit operator ColorVariable(Color input) {
            var fR = new ColorVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}