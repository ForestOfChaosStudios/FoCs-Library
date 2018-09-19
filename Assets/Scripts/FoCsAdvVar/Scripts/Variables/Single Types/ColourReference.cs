using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaos] public class ColourReference: AdvReference<Colour> { }

	[Serializable]
	public class ColourVariable: AdvVariable<Colour, ColourReference>
	{
		public static implicit operator ColourVariable(Colour input)
		{
			var fR = new ColourVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
