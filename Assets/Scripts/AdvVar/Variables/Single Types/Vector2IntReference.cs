using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnity]
	public class Vector2IntReference: AdvReference<Vector2Int>
	{ }

	[Serializable]
	public class Vector2IntVariable: AdvVariable<Vector2Int, Vector2IntReference>
	{
		public static implicit operator Vector2IntVariable(Vector2Int input)
		{
			var fR = new Vector2IntVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}