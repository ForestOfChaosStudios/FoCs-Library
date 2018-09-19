using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using ForestOfChaosLibrary.Types;
using UnityEngine;

namespace ForestOfChaosLibrary.Grid
{
	public static class GridUtilities
	{
		public static GridPosition GetGridPosition(this Ray     ray) => GetGridPosition(ray.GetPosOnY());
		public static GridPosition GetGridPosition(this Vector3 v3) => new Vector2I(v3.x.CastToInt(), v3.z.CastToInt());
	}
}
