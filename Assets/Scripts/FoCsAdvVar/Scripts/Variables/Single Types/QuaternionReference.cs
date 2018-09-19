using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class QuaternionReference: AdvReference<Quaternion> { }

	[Serializable]
	public class QuaternionVariable: AdvVariable<Quaternion, QuaternionReference>
	{
		public static implicit operator QuaternionVariable(Quaternion input)
		{
			var fR = new QuaternionVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
