using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameForestOfChaosLists] public class Vector3IListReference: AdvListReference<Vector3I> { }

	[Serializable] public class Vector3IListVariable: AdvListVariable<Vector3I, Vector3IListReference> { }
}