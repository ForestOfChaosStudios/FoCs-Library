using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
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
