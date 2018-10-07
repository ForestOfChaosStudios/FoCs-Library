using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class Vector2IListReference: AdvListReference<Vector2I> { }

	[Serializable] public class Vector2IListVariable: AdvListVariable<Vector2I, Vector2IListReference> { }
}
