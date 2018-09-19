using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class Vector4IListReference: AdvListReference<Vector4I> { }

	[Serializable] public class Vector4IListVariable: AdvListVariable<Vector4I, Vector4IListReference> { }
}
