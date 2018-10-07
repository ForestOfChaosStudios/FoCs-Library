using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class TransformReference: AdvReference<Transform> { }

	[Serializable]
	public class TransformVariable: AdvVariable<Transform, TransformReference>
	{
		public static implicit operator TransformVariable(Transform input)
		{
			var fR = new TransformVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
