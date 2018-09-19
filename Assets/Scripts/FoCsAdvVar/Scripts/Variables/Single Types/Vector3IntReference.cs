using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class Vector3IntReference: AdvReference<Vector3Int> { }

	[Serializable]
	public class Vector3IntVariable: AdvVariable<Vector3Int, Vector3IntReference>
	{
		public static implicit operator Vector3IntVariable(Vector3Int input)
		{
			var fR = new Vector3IntVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
