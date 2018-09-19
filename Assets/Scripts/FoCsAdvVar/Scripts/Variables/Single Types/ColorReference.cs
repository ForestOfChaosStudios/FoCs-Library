using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class ColorReference: AdvReference<Color> { }

	[Serializable]
	public class ColorVariable: AdvVariable<Color, ColorReference>
	{
		public static implicit operator ColorVariable(Color input)
		{
			var fR = new ColorVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
