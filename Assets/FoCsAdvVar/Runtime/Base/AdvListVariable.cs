#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvListVariable.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    [Serializable]
    public class AdvListVariable<T, aT>: AdvListVariable where aT: AdvListReference<T> {
        [SerializeField]
        private List<T> ConstantValue;

        public bool UseConstant = true;

        [SerializeField]
        private aT Variable;

        public List<T> Value => UseConstant? ConstantValue : Variable.Value;
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvListVariable { }
}