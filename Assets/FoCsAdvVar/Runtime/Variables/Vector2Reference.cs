#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: Vector2Reference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameUnity]
    [CreateAssetMenu(fileName = "New " + nameof(Vector2Reference), menuName = "ADV Variables/" + nameof(AdvReference) + "/" + nameof(Vector2Reference), order = 0)]
    public class Vector2Reference: AdvReference<Vector2> { }

    [Serializable]
    public class Vector2Variable: AdvVariable<Vector2> {
        public static implicit operator Vector2Variable(Vector2 input) {
            var fR = new Vector2Variable {UseLocal = true, Value = input};

            return fR;
        }
    }
}