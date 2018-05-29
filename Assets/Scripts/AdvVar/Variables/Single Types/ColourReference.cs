using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameForestOfChaos] public class ColourReference: AdvReference<Colour> { }

	[Serializable]
	public class ColourVariable: AdvVariable<Colour, ColourReference>
	{
		public static implicit operator ColourVariable(Colour input)
		{
			var fR = new ColourVariable
			{
					UseConstant = true,
					Value       = input
			};

			return fR;
		}
	}
}