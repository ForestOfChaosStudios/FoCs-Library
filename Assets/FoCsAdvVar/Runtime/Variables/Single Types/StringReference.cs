﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: StringReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameSystem]
    public class StringReference: AdvReference<string> { }

    [Serializable]
    public class StringVariable: AdvVariable<string> {
        public static implicit operator StringVariable(string input) {
            var fR = new StringVariable {UseLocal = true, Value = input};

            return fR;
        }
    }
}