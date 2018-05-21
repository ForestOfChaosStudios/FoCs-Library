using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameSystemTypeLists]
	public class BoolListReference: AdvListReference<bool>
	{ }

	[Serializable]
	public class BoolListVariable: AdvListVariable<bool, BoolListReference>
	{ }
}