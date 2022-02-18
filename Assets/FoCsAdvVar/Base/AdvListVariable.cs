#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvListVariable.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    [Serializable]
    public class AdvListVariable<TList> : AdvListVariable {
        [SerializeField]
        private List<TList> ConstantValue;

        public bool UseConstant = true;

        [SerializeField]
        private AdvListReference<TList> Variable;

        public List<TList> Value => UseConstant? ConstantValue : Variable.Value;
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvListVariable { }
}