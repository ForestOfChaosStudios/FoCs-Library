using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class ColourListReference: AdvListReference<Colour> { }

	[Serializable] public class ColourListVariable: AdvListVariable<Colour, ColourListReference> { }
}
