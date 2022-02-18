#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ITDCurveComponent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using ForestOfChaos.Unity.Types;

namespace ForestOfChaos.Unity.Maths.Curves.Components {
    public class ITDCurveComponent<TCurve>: ICurveTDComponent, ITDCurve where TCurve: ITDCurve {
        public TCurve Curve;

        public override bool UseGlobalSpace {
            get => Curve.UseGlobalSpace;
            set => Curve.UseGlobalSpace = value;
        }

        public override List<TransformData> CurvePositions {
            get => Curve.CurvePositions;
            set => Curve.CurvePositions = value;
        }

        public override bool IsFixedLength => Curve.IsFixedLength;

        public override int Length => Curve.Length;

        public override TransformData Lerp(float time) {
            if (!UseGlobalSpace) {
                var lerpTime = Curve.Lerp(time);
                lerpTime.Position = transform.TransformPoint(lerpTime.Position);

                return lerpTime;
            }
            else {
                var lerpTime = Curve.Lerp(time);

                return lerpTime;
            }
        }
    }

    public abstract class ICurveTDComponent: FoCsBehaviour {
        public abstract List<TransformData> CurvePositions { get; set; }

        public abstract bool IsFixedLength { get; }

        public abstract bool UseGlobalSpace { get; set; }

        public abstract int Length { get; }

        public abstract TransformData Lerp(float time);
    }
}