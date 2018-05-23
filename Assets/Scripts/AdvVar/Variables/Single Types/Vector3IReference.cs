﻿using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameForestOfChaos]
	public class Vector3IReference: AdvReference<Vector3I>
	{ }

	[Serializable]
	public class Vector3IVariable: AdvVariable<Vector3I, Vector3IReference>
	{
		public static implicit operator Vector3IVariable(Vector3I input)
		{
			var fR = new Vector3IVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}