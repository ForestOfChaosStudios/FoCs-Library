#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TDCurve2Points.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Maths.Lerp;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves {
    [Serializable]
    public class TDCurve2Points: ITDCurve {
        public const int TOTAL_COUNT = 2;

        [SerializeField]
        private List<TransformData> Positions = new List<TransformData>(TOTAL_COUNT);

        [SerializeField]
        private bool useGlobalSpace;

        public TransformData StartPos {
            get => Positions[0];
            set => Positions[0] = value;
        }

        public TransformData EndPos {
            get => Positions[1];
            set => Positions[1] = value;
        }

        private void PosNullCheck() {
            if (Positions == null)
                Positions = new List<TransformData>(TOTAL_COUNT);
        }

        public bool UseGlobalSpace {
            get => useGlobalSpace;
            set => useGlobalSpace = value;
        }

        public List<TransformData> CurvePositions {
            get {
                PosNullCheck();

                return Positions;
            }
            set {
                PosNullCheck();

                if (value.IsNullOrEmpty())
                    return;

                switch (value.Count) {
                    case 0: return;
                    case 1:
                        StartPos = value[0];

                        return;
                    default:
                        StartPos = value[0];
                        EndPos   = value[1];

                        break;
                }
            }
        }

        public bool IsFixedLength => true;

        public int Length => TOTAL_COUNT;

        public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
    }
}