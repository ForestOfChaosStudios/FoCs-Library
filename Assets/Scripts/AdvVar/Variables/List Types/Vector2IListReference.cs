using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class Vector2IListReference: AdvListReference<Vector2I> { }

	[Serializable] public class Vector2IListVariable: AdvListVariable<Vector2I, Vector2IListReference> { }
}
