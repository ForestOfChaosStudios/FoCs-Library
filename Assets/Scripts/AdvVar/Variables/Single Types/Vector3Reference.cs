using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnity] public class Vector3Reference: AdvReference<Vector3> { }

	[Serializable]
	public class Vector3Variable: AdvVariable<Vector3, Vector3Reference>
	{
		public static implicit operator Vector3Variable(Vector3 input)
		{
			var fR = new Vector3Variable
			{
					UseConstant = true,
					Value       = input
			};

			return fR;
		}
	}
}