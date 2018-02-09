using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameForestOfChaosLists]
	public class Vector4IListReference: AdvListReference<Vector4I>
	{ }

	[Serializable]
	public class Vector4IListVariable: AdvListVariable<Vector4I, Vector4IListReference>
	{ }
}