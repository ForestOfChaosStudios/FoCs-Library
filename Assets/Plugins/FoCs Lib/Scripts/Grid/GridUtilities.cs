using ForestOfChaosLib.Types;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEngine;

namespace ForestOfChaosLib.Grid
{
	public static class GridUtilities
	{
		public static GridPosition GetGridPosition(this Ray ray) => GetGridPosition(ray.GetPosOnY());
		public static GridPosition GetGridPosition(this Vector3 v3) => new Vector2I(v3.x.CastToInt(), v3.z.CastToInt());
	}
}