#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TDCurve3Points.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Maths.Lerp;
using ForestOfChaos.Unity.Types;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves {
    [Serializable]
    public class TDCurve3Points: ITDCurve {
        public const int TOTAL_COUNT = 3;

        [SerializeField]
        private List<TransformData> Positions = new List<TransformData>(TOTAL_COUNT);

        [SerializeField]
        private bool useGlobalSpace;

        public TransformData StartPos {
            get => Positions[0];
            set => Positions[0] = value;
        }

        public TransformData MidPos {
            get => Positions[1];
            set => Positions[1] = value;
        }

        public TransformData EndPos {
            get => Positions[2];
            set => Positions[2] = value;
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
                    case 2:
                        StartPos = value[0];
                        MidPos   = value[1];

                        return;
                    case 3:
                        StartPos = value[0];
                        MidPos   = value[1];
                        EndPos   = value[2];

                        return;
                    default:
                        StartPos = value[0];
                        MidPos   = value[1];
                        EndPos   = value[2];

                        break;
                }
            }
        }

        public bool IsFixedLength => true;

        public int Length => TOTAL_COUNT;

        public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
    }
}