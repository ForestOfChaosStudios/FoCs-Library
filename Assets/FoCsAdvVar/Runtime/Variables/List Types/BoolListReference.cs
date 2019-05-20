using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class BoolListReference: AdvListReference<bool> { }

	[Serializable] public class BoolListVariable: AdvListVariable<bool, BoolListReference> { }
}
