#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2Reference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    public class Vector2Reference: AdvReference<Vector2> { }

    [Serializable]
    public class Vector2Variable: AdvVariable<Vector2> {
        public static implicit operator Vector2Variable(Vector2 input) {
            var fR = new Vector2Variable {UseLocal = true, Value = input};

            return fR;
        }
    }
}