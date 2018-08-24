using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Maths.Curves
{
	public interface ICurveTD
	{
		List<TransformData> CurvePositions { get; set; }
		bool                IsFixedLength  { get; }
		bool                UseGlobalSpace { get; set; }
		int                 Length         { get; }
		TransformData Lerp(float time);
	}
}
