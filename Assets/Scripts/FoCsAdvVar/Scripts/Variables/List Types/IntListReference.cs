using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystemTypeLists] public class IntListReference: AdvListReference<int> { }

	[Serializable] public class IntListVariable: AdvListVariable<int, IntListReference> { }
}
