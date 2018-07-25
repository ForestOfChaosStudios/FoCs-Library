using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves
{
	public interface ICurveTD
	{
		List<TransformData> CurvePositions { get; set; }
		bool                IsFixedLength  { get; }
		int                 Length         { get; }
		TransformData Lerp(float time);
	}
}