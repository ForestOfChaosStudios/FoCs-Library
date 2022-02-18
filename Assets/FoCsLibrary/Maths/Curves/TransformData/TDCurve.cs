#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TDCurve.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Maths.Lerp;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves {
    [Serializable]
    public class TDCurve: ITDCurve {
        [SerializeField]
        private List<TransformData> Positions;

        [SerializeField]
        private bool useGlobalSpace;

        public bool UseGlobalSpace {
            get => useGlobalSpace;
            set => useGlobalSpace = value;
        }

        public List<TransformData> CurvePositions {
            get => Positions;
            set => Positions = value;
        }

        public bool IsFixedLength => false;

        public int Length => Positions.Count;

        public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
    }
}