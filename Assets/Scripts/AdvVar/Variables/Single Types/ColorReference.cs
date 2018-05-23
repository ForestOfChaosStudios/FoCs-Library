using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnity]
	public class ColorReference: AdvReference<Color>
	{ }

	[Serializable]
	public class ColorVariable: AdvVariable<Color, ColorReference>
	{
		public static implicit operator ColorVariable(Color input)
		{
			var fR = new ColorVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}

}