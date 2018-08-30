using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnity] public class Vector4Reference: AdvReference<Vector4> { }

	[Serializable]
	public class Vector4Variable: AdvVariable<Vector4, Vector4Reference>
	{
		public static implicit operator Vector4Variable(Vector4 input)
		{
			var fR = new Vector4Variable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
