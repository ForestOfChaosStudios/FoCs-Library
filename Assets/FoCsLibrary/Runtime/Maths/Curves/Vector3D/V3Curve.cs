#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: V3Curve.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Maths.Lerp;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves {
    [Serializable]
    public class V3Curve: IV3Curve {
        [SerializeField]
        private List<Vector3> Positions = new List<Vector3>();

        [SerializeField]
        private bool useGlobalSpace = true;

        public bool UseGlobalSpace {
            get => useGlobalSpace;
            set => useGlobalSpace = value;
        }

        public List<Vector3> CurvePositions {
            get => Positions;
            set => Positions = value;
        }

        public bool IsFixedLength => false;

        public int Length => Positions.Count;

        public Vector3 Lerp(float time) => Vector3Lerp.Lerp(Positions, time);
    }
}