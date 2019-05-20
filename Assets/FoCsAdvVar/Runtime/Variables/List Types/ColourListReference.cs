using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class ColourListReference: AdvListReference<Colour> { }

	[Serializable] public class ColourListVariable: AdvListVariable<Colour, ColourListReference> { }
}
