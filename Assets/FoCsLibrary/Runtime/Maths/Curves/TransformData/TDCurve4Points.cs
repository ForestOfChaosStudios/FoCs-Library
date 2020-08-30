#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: TDCurve4Points.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using System.Collections.Generic;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Maths.Lerp;
using ForestOfChaosLibrary.Types;
using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves {
    [Serializable]
    public class TDCurve4Points: ITDCurve {
        public const int TOTAL_COUNT = 4;

        [SerializeField]
        private List<TransformData> Positions = new List<TransformData>(TOTAL_COUNT);

        [SerializeField]
        private bool useGlobalSpace;

        public TransformData StartPos {
            get => Positions[0];
            set => Positions[0] = value;
        }

        public TransformData MidPosOne {
            get => Positions[1];
            set => Positions[1] = value;
        }

        public TransformData MidPosTwo {
            get => Positions[2];
            set => Positions[2] = value;
        }

        public TransformData EndPos {
            get => Positions[3];
            set => Positions[3] = value;
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
                        StartPos  = value[0];
                        MidPosOne = value[1];

                        return;
                    case 3:
                        StartPos  = value[0];
                        MidPosOne = value[1];
                        MidPosTwo = value[2];

                        return;
                    case 4:
                        StartPos  = value[0];
                        MidPosOne = value[1];
                        MidPosTwo = value[2];
                        EndPos    = value[3];

                        return;
                    default:
                        StartPos  = value[0];
                        MidPosOne = value[1];
                        MidPosTwo = value[2];
                        EndPos    = value[3];

                        break;
                }
            }
        }

        public bool IsFixedLength => true;

        public int Length => TOTAL_COUNT;

        public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
    }
}