#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: TDCurve.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using System.Collections.Generic;
using ForestOfChaosLibrary.Maths.Lerp;
using ForestOfChaosLibrary.Types;
using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves {
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