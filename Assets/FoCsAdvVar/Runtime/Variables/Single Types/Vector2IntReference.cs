using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class Vector2IntReference: AdvReference<Vector2Int> { }

	[Serializable]
	public class Vector2IntVariable: AdvVariable<Vector2Int, Vector2IntReference>
	{
		public static implicit operator Vector2IntVariable(Vector2Int input)
		{
			var fR = new Vector2IntVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
