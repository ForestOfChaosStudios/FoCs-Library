#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: IV3CurveComponent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    public class IV3CurveComponent<TCurve>: ICurveV3DComponent, IV3Curve where TCurve: IV3Curve {
        public TCurve Curve;

        public override bool UseGlobalSpace {
            get => Curve.UseGlobalSpace;
            set => Curve.UseGlobalSpace = value;
        }

        public override List<Vector3> CurvePositions {
            get => Curve.CurvePositions;
            set => Curve.CurvePositions = value;
        }

        public override bool IsFixedLength => Curve.IsFixedLength;

        public override int Length => Curve.Length;

        public override Vector3 Lerp(float time) {
            if (!UseGlobalSpace)
                return transform.TransformDirection(Curve.Lerp(time) + transform.position);

            return Curve.Lerp(time);
        }
    }

    public abstract class ICurveV3DComponent: FoCsBehaviour {
        public abstract bool UseGlobalSpace { get; set; }

        public abstract List<Vector3> CurvePositions { get; set; }

        public abstract bool IsFixedLength { get; }

        public abstract int Length { get; }

        public abstract Vector3 Lerp(float time);
    }
}