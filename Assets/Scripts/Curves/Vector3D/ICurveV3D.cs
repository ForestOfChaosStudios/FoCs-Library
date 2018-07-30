using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves
{
	public interface ICurveV3D
	{
		List<Vector3> CurvePositions { get; set; }
		bool          IsFixedLength  { get; }
		bool          UseGlobalSpace { get; set; }
		int           Length         { get; }
		Vector3 Lerp(float time);
	}
}
