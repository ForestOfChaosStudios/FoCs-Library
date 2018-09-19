using System.Collections.Generic;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosLibrary.Maths.Curves
{
	public interface ITDCurve
	{
		List<TransformData> CurvePositions { get; set; }
		bool                IsFixedLength  { get; }
		bool                UseGlobalSpace { get; set; }
		int                 Length         { get; }
		TransformData Lerp(float time);
	}
}
