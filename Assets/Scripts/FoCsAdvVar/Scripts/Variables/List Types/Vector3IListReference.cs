using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class Vector3IListReference: AdvListReference<Vector3I> { }

	[Serializable] public class Vector3IListVariable: AdvListVariable<Vector3I, Vector3IListReference> { }
}
